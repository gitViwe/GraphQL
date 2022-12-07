using Application.GraphQL.TypeDescriptor;
using Infrastructure.GraphQL.Mutation;
using Infrastructure.GraphQL.Query;
using Infrastructure.GraphQL.Subscription;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddGraphQLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPooledDbContextFactory<DatabaseContext>(options =>
        {
            // using an SQlite provider
            options.UseSqlite(configuration.GetConnectionString("SQLite")!, b => b.MigrationsAssembly("Infrastructure"));
        });

        services
            .AddGraphQLServer()
            .AddType<SuperHeroDescriptor>()
            .AddType<SuperHeroInputDescriptor>()
            .AddType<SuperHeroOutputDescriptor>()
            .AddQueryType<SuperHeroQuery>()
            .AddMutationType<SuperHeroMutation>()
            .AddSubscriptionType<SuperHeroSubscription>()
            .AddInMemorySubscriptions()
            .AddAuthorization();

        return services;
    }

    public static void UseGraphQLServices(this IEndpointRouteBuilder app)
    {
        app.MapGraphQL();
    }

    public static async Task ApplyMigrationAsync(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DatabaseContext>>();

        using var context = await contextFactory.CreateDbContextAsync();
        await context.Database.MigrateAsync();
    }
}