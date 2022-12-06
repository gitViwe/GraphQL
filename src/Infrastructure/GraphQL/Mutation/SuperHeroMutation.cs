using Application.GraphQL.TypeDescriptor;
using Domain;
using HotChocolate.Subscriptions;
using Infrastructure.GraphQL.Subscription;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GraphQL.Mutation;

[GraphQLDescription("Represents the mutations available.")]
public class SuperHeroMutation
{
    public async Task<SuperHeroOutput> AddSuperHeroAsync(
        SuperHeroInput input,
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var newHero = new SuperHero()
        {
            Name = input.Name,
            Alias = input.Alias,
        };

        await context.Heroes.AddAsync(newHero, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var output = new SuperHeroOutput(newHero.Id, newHero.Name, newHero.Alias);

        await eventSender.SendAsync(nameof(SuperHeroSubsription.HeroCreated), output, cancellationToken);

        return output;
    }

    public async Task<SuperHeroOutput> UpdateSuperHeroAsync(
        long superHeroId,
        SuperHeroInput input,
        [Service] IDbContextFactory<DatabaseContext> contextFactory,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var heroToUpdate = await context.Heroes.FirstAsync(x => x.Id == superHeroId) ?? throw new GraphQLException("Hero does not exist.");

        heroToUpdate.Name = input.Name;
        heroToUpdate.Alias = input.Alias;

        await context.SaveChangesAsync(cancellationToken);

        var output = new SuperHeroOutput(heroToUpdate.Id, heroToUpdate.Name, heroToUpdate.Alias);
        string topicName = $"{heroToUpdate.Id}_{nameof(SuperHeroSubsription.HeroUpdated)}";
        await eventSender.SendAsync(topicName, output, cancellationToken);

        return output;
    }
}
