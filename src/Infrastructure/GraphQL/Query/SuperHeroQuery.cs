using Domain;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GraphQL.Query;

/// <summary>
/// Represents the graphQL queries
/// </summary>
[GraphQLDescription("The base query class to encapsulate the GraphQL queries")]
public class SuperHeroQuery
{
    /// <summary>
    /// Gets the hero objects
    /// </summary>
    /// <param name="contextFactory">Tha database context used</param>
    /// <returns>A queryable hero collection</returns>
    [GraphQLDescription("Gets the queryable heroes.")]
    [UseDbContext(typeof(DatabaseContext))]
    public async Task<IQueryable<SuperHero>> GetHeroesAsync([Service] IDbContextFactory<DatabaseContext> contextFactory)
    {
        var context = await contextFactory.CreateDbContextAsync();
        return context.Heroes;
    }
}
