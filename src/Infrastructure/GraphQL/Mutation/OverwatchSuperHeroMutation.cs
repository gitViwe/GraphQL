using Application.GraphQL.Attribute;
using Application.GraphQL.ContextData;
using Application.GraphQL.TypeDescriptor;
using Domain;
using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using Infrastructure.Extension;
using Infrastructure.GraphQL.Subscription;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GraphQL.Mutation;

[GraphQLDescription("The  class to encapsulate the GraphQL mutations for Overwatch Super Heroes")]
public class OverwatchSuperHeroMutation
{
    [Authorize]
    [ResolveCurrentUser]
    [GraphQLDescription("The mutation to deploy a hero.")]
    public async Task<OverwatchDeploymentOutput> DeployOverwatchHeroAsync(
        OverwatchDeploymentInput input,
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        [Service] ITopicEventSender eventSender,
        [CurrentUser] CurrentUser user,
        CancellationToken cancellationToken = default)
    {
        using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var map = await context.OverwatchMaps
                               .AsNoTracking()
                               .Include(x => x.Gamemodes)
                               .Where(x => x.Gamemodes.Any(mode => mode.Id == input.GameModeId))
                               .FirstOrDefaultAsync(cancellationToken)
                               ?? throw new GraphQLException(new Error("Game mode does not exist.", "NOT_FOUND"));

        var hero = await context.OverwatchSuperHeroes
                                .AsNoTracking()
                                .ApplyDefaultIncludes()
                                .Where(x => x.Id == input.SuperHeroId)
                                .FirstOrDefaultAsync(cancellationToken)
                                ?? throw new GraphQLException(new Error("Super hero does not exist.", "NOT_FOUND"));

        var deployment = new OverwatchDeployment
        {
            CombatMapId = map.Id,
            DeployedAt = DateTime.UtcNow,
            DeployedBy = user.UserId,
            GameModeId = input.GameModeId,
            SuperHeroId = hero.Id,
        };

        await context.OverwatchDeployments.AddAsync(deployment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var output = new OverwatchDeploymentOutput(
            Id: deployment.Id,
            CombatMapId: deployment.CombatMapId,
            GameMode: map.Gamemodes.First(x => x.Id == input.GameModeId),
            SuperHero: hero,
            DeployedAt: deployment.DeployedAt);

        await eventSender.SendAsync(nameof(OverwatchSuperHeroSubscription.SuperHeroDeployed), output, cancellationToken);

        return output;
    }
}
