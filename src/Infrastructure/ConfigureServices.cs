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
using System.Reflection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddGraphQLServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddPooledDbContextFactory<DatabaseContext>(options =>
        {
            if (environment.IsDevelopment())
            {
                options.UseSqlite(configuration.GetConnectionString(ConfigurationKey.ConnectionString.SQLite));
            }
            else
            {
                options.UseNpgsql(configuration.GetConnectionString(ConfigurationKey.ConnectionString.PostgreSQL)!, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            }
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

    public static async Task ApplyMigrationAsync(this IHost host, IHostEnvironment environment)
    {
        using IServiceScope scope = host.Services.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DatabaseContext>>();

        using var context = await contextFactory.CreateDbContextAsync();
        if (environment.IsDevelopment())
        {
            await context.Database.EnsureCreatedAsync();
        }
        else
        {
            await context.Database.MigrateAsync();
        }
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
