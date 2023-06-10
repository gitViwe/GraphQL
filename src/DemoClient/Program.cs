// See https://aka.ms/new-console-template for more information
using Application.GraphQL.TypeDescriptor;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using System.Text.Json;

Console.WriteLine("Hello, World!");

using var graphQLClient = new GraphQLHttpClient("https://localhost:7166/graphql", new SystemTextJsonSerializer());

var request = new GraphQLRequest
{
    Query = File.ReadAllText("graphql/subscription/superherodeployed.graphql")
};

IObservable<GraphQLResponse<SubscriptionResult>> subscriptionStream = graphQLClient.CreateSubscriptionStream<SubscriptionResult>(request);

using var subscription = subscriptionStream.Subscribe(response =>
{
    Console.WriteLine(JsonSerializer.Serialize(response.Data, new JsonSerializerOptions { WriteIndented = true }));
});

Console.ReadKey();
public class SubscriptionResult
{
    public OverwatchDeploymentOutput SuperHeroDeployed { get; set; }
}