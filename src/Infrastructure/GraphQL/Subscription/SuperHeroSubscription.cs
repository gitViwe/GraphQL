using Application.GraphQL.TypeDescriptor;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Infrastructure.GraphQL.Subscription;

[GraphQLDescription("The  class to encapsulate the GraphQL subscriptions for SuperHero")]
public class SuperHeroSubscription
{
    [Subscribe]
    [GraphQLDescription("The subscription for added heroes.")]
    public SuperHeroOutput HeroCreated([EventMessage] SuperHeroOutput superHero) => superHero;

    [SubscribeAndResolve]
    [GraphQLDescription("The subscription for updated heroes.")]
    public async ValueTask<ISourceStream<SuperHeroOutput>> HeroUpdated(long heroId, [Service] ITopicEventReceiver eventReceiver)
    {
        string topicName = $"{heroId}_{nameof(SuperHeroSubscription.HeroUpdated)}";
        return await eventReceiver.SubscribeAsync<string, SuperHeroOutput>(topicName);
    }
}
