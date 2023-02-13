using Application.GraphQL.TypeDescriptor;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Infrastructure.GraphQL.Subscription;

[GraphQLDescription("The  class to encapsulate the GraphQL subscriptions for SuperHero")]
public class SuperHeroSubscription
{
    [Subscribe]
    [Topic(nameof(SuperHeroSubscription.HeroCreated))]
    [GraphQLDescription("The subscription for added heroes.")]
    public SuperHeroOutput HeroCreated([EventMessage] SuperHeroOutput output) => output;

    [SubscribeAndResolve]
    [GraphQLDescription("The subscription for updated heroes.")]
    public async ValueTask<ISourceStream<SuperHeroOutput>> HeroUpdated(long heroId, [Service] ITopicEventReceiver eventReceiver)
    {
        string topicName = $"{heroId}_{nameof(SuperHeroSubscription.HeroUpdated)}";
        return await eventReceiver.SubscribeAsync<SuperHeroOutput>(topicName);
    }
}
