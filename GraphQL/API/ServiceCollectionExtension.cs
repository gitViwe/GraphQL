using API.GraphQL;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class ServiceCollectionExtension
{
    public static void AddGraphQLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlite(configuration.GetConnectionString("SQLite")));

        services
            .AddGraphQLServer()
            .AddType<HeroDescriptor>()
            .AddQueryType<GraphQuery>();
    }

    public static void UseGraphQLServices(this WebApplication app)
    {
        app.MapGraphQL();
    }
}
