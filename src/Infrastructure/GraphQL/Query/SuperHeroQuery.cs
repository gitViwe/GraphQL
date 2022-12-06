using Domain;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GraphQL.Query;

[GraphQLDescription("The  class to encapsulate the GraphQL queries for SuperHero")]
public class SuperHeroQuery
{
    [GraphQLDescription("Gets the queryable heroes.")]
    public async Task<IQueryable<SuperHero>> GetHeroesAsync([Service] IDbContextFactory<DatabaseContext> contextFactory)
    {
        var context = await contextFactory.CreateDbContextAsync();
        return context.Heroes;
    }
}
