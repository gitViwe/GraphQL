using Domain;
using HotChocolate.Types;

namespace Application.GraphQL.TypeDescriptor;

public record OverwatchDeploymentOutput(int Id, int CombatMapId, OverwatchMode GameMode, OverwatchSuperHero SuperHero, DateTime DeployedAt);

public class OverwatchDeploymentOutputDescriptor : ObjectType<OverwatchDeploymentOutput>
{
    protected override void Configure(IObjectTypeDescriptor<OverwatchDeploymentOutput> descriptor)
    {
        descriptor.Description("Represents the input to deploy a hero.");

        descriptor.Field(p => p.CombatMapId)
                  .Description("The identifier for the combat map.");

        descriptor.Field(p => p.GameMode)
                  .Description("The battle ground details.");

        descriptor.Field(p => p.SuperHero)
                  .Description("The super hero details.");

        descriptor.Field(p => p.DeployedAt)
                  .Description("When the deployment was authorised.");
    }
}
