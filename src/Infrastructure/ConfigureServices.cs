using Application.Constant;
using Application.GraphQL.TypeDescriptor;
using Infrastructure.GraphQL.Mutation;
using Infrastructure.GraphQL.Query;
using Infrastructure.GraphQL.Subscription;
using Infrastructure.Persistance;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddGraphQLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPooledDbContextFactory<DatabaseContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString(ConfigurationKey.ConnectionString.SQLite));
        });

        services.AddSingleton<OverwatchDataService>();

        services
            .AddGraphQLServer()
            .AddType<OverwatchSuperHeroDescriptor>()
            .AddType<OverwatchDeploymentInputDescriptor>()
            .AddType<OverwatchDeploymentOutputDescriptor>()
            .AddQueryType<OverwatchSuperHeroQuery>()
            .AddMutationType<OverwatchSuperHeroMutation>()
            .AddSubscriptionType<OverwatchSuperHeroSubscription>()
            .AddInMemorySubscriptions()
            .AddAuthorization();

        return services;
    }

    public static void RegisterOpenTelemetry(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        var resource = ResourceBuilder.CreateDefault().AddService(configuration[ConfigurationKey.API.ApplicationName]!);

        services.AddOpenTelemetry().WithTracing(builder =>
        {
            builder.SetResourceBuilder(resource)
                   .AddHttpClientInstrumentation(options =>
                   {
                       options.RecordException = true;
                       options.EnrichWithException = (activity, exception) => activity?.RecordException(exception);
                   })
                   .AddEntityFrameworkCoreInstrumentation(x => x.SetDbStatementForText = true)
                   .AddAspNetCoreInstrumentation(options =>
                   {
                       options.RecordException = true;
                       options.EnrichWithException = (activity, exception) => activity.RecordException(exception);
                   });
            if (environment.IsProduction())
            {
                builder.AddOtlpExporter(option =>
                {
                    option.Endpoint = new Uri(configuration[ConfigurationKey.OpenTelemetry.Honeycomb.Endpoint]!);
                    option.Headers = configuration[ConfigurationKey.OpenTelemetry.Honeycomb.Headers]!;
                });
            }
            else
            {
                builder.AddJaegerExporter(options =>
                {
                    options.AgentHost = configuration[ConfigurationKey.OpenTelemetry.Jaeger.AgentHost]!;
                    options.AgentPort = int.Parse(configuration[ConfigurationKey.OpenTelemetry.Jaeger.AgentPort]!);
                });
            }
        });
    }

    public static async Task EnsureDatabaseCreatedAsync(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DatabaseContext>>();

        using var context = await contextFactory.CreateDbContextAsync();
        await context.Database.EnsureCreatedAsync();
    }

    public static async Task SeedDataAsync(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DatabaseContext>>();
        var dataService = scope.ServiceProvider.GetRequiredService<OverwatchDataService>();

        using var context = await contextFactory.CreateDbContextAsync();

        if (!context.OverwatchSuperHeroes.Any())
        {
            var heroes = await dataService.GetOverwatchHeroesAsync();
            var heroDetails = dataService.GetOverwatchHeroDetails();
            var heroRoles = await dataService.GetOverwatchHeroRolesAsync();
            await context.OverwatchSuperHeroes.AddRangeAsync(heroes.Select(x => x.ToOverwatchSuperHero().AddDetail(heroDetails, heroRoles.Select(x => x.ToOverwatchSuperHeroRole()))));
        }

        if (!context.OverwatchMaps.Any())
        {
            var gameModes = await dataService.GetOverwatchGameModesAsync();
            var maps = await dataService.GetOverwatchMapsAsync();
            await context.OverwatchMaps.AddRangeAsync(maps.Select(x => x.ToOverwatchCombatMap(gameModes.Select(x => x.ToOverwatchMode()))));
        }

        await context.SaveChangesAsync();
    }
}
