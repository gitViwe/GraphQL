using Application.GraphQL.TypeDescriptor;

namespace Infrastructure.GraphQL.Subscription;

[GraphQLDescription("The  class to encapsulate the GraphQL subscriptions for Overwatch Super Hero")]
public class OverwatchSuperHeroSubscription
{
    [Subscribe]
    [Topic(nameof(SuperHeroDeployed))]
    [GraphQLDescription("The subscription for Overwatch Super Hero deployments.")]
    public OverwatchDeploymentOutput SuperHeroDeployed([EventMessage] OverwatchDeploymentOutput output) => output;
}
