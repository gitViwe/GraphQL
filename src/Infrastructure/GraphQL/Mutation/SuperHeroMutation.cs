using Application.GraphQL.Attribute;
using Application.GraphQL.ContextData;
using Application.GraphQL.TypeDescriptor;
using Domain;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;
using Infrastructure.GraphQL.Subscription;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GraphQL.Mutation;

[GraphQLDescription("The  class to encapsulate the GraphQL mutations for SuperHero")]
public class SuperHeroMutation
{
    [Authorize]
    [ResolveCurrentUser]
    [GraphQLDescription("The mutation to add heroes.")]
    public async Task<SuperHeroOutput> AddSuperHeroAsync(
        SuperHeroInput input,
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        [Service] ITopicEventSender eventSender,
        [CurrentUser] CurrentUser user,
        CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var newHero = new SuperHero()
        {
            Name = input.Name,
            Alias = input.Alias,
            CreatedBy = user.UserId,
        };

        await context.Heroes.AddAsync(newHero, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var output = new SuperHeroOutput(newHero.Id, newHero.Name, newHero.Alias);

        await eventSender.SendAsync(nameof(SuperHeroSubscription.HeroCreated), output, cancellationToken);

        return output;
    }

    [Authorize]
    [ResolveCurrentUser]
    [GraphQLDescription("The mutation to update heroes.")]
    public async Task<SuperHeroOutput> UpdateSuperHeroAsync(
        long superHeroId,
        SuperHeroInput input,
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        [Service] ITopicEventSender eventSender,
        [CurrentUser] CurrentUser user,
        CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var heroToUpdate = await context.Heroes.FirstOrDefaultAsync(x => x.Id == superHeroId)
            ?? throw new GraphQLException(new Error("Hero does not exist.", "NOT_FOUND_ERROR"));

        if (heroToUpdate.CreatedBy != user.UserId)
        {
            throw new GraphQLException(new Error("User can only update items they created.", "NOT_ALLOWED"));
        }

        heroToUpdate.Name = input.Name;
        heroToUpdate.Alias = input.Alias;

        await context.SaveChangesAsync(cancellationToken);

        var output = new SuperHeroOutput(heroToUpdate.Id, heroToUpdate.Name, heroToUpdate.Alias);
        string topicName = $"{heroToUpdate.Id}_{nameof(SuperHeroSubscription.HeroUpdated)}";
        await eventSender.SendAsync(topicName, output, cancellationToken);

        return output;
    }
}
