using Application.GraphQL.TypeDescriptor;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Infrastructure.GraphQL.Subscription;

public class SuperHeroSubsription
{
    [Subscribe]
    [Topic]
    [GraphQLDescription("The subscription for added heroes.")]
    public SuperHeroOutput HeroCreated([EventMessage] SuperHeroOutput superHero) => superHero;

    [SubscribeAndResolve]
    public async ValueTask<ISourceStream<SuperHeroOutput>> HeroUpdated(int heroId, [Service] ITopicEventReceiver eventReceiver)
    {
        string topicName = $"{heroId}_{nameof(SuperHeroSubsription.HeroUpdated)}";
        return await eventReceiver.SubscribeAsync<string, SuperHeroOutput>(topicName);
    }
}
