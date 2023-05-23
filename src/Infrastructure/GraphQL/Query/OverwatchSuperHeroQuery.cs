using Domain;
using Infrastructure.Extension;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GraphQL.Query;

[GraphQLDescription("The  class to encapsulate the GraphQL queries for Overwatch Super Heroes")]
public class OverwatchSuperHeroQuery
{
    [GraphQLDescription("The query for the Overwatch Super Heroes.")]
    public async Task<IQueryable<OverwatchSuperHero>> GetOverwatchSuperHeroesAsync(
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        CancellationToken cancellationToken = default)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return context.OverwatchSuperHeroes
                      .AsNoTracking()
                      .ApplyDefaultIncludes();
    }

    [GraphQLDescription("The query for a single Overwatch Super Hero.")]
    public async Task<IQueryable<OverwatchSuperHero>> GetOverwatchSuperHeroAsync(
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        int id,
        CancellationToken cancellationToken = default)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return context.OverwatchSuperHeroes
                      .AsNoTracking()
                      .ApplyDefaultIncludes()
                      .Where(x => x.Id == id);
    }

    [GraphQLDescription("The query for the Overwatch Battle Grounds.")]
    public async Task<IQueryable<OverwatchCombatMap>> GetOverwatchMapsAsync(
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        CancellationToken cancellationToken = default)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return context.OverwatchMaps
                      .AsNoTracking()
                      .Include(x => x.Gamemodes);
    }

    [GraphQLDescription("The query for a single Overwatch Battle Ground.")]
    public async Task<IQueryable<OverwatchCombatMap>> GetOverwatchMapAsync(
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        int id,
        CancellationToken cancellationToken = default)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        return context.OverwatchMaps
                      .AsNoTracking()
                      .Include(x => x.Gamemodes)
                      .Where(x => x.Id == id);
    }
}
