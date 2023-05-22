using HotChocolate.Types;

namespace Application.GraphQL.TypeDescriptor;

public record OverwatchDeploymentInput(int GameModeId, int SuperHeroId);

public class OverwatchDeploymentInputDescriptor : InputObjectType<OverwatchDeploymentInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<OverwatchDeploymentInput> descriptor)
    {
        descriptor.Description("Represents the input to deploy a hero.");

        descriptor.Field(p => p.SuperHeroId)
                  .Description("The identifier for the hero.");

        descriptor.Field(p => p.GameModeId)
                  .Description("The identifier for the battle ground.");
    }
}
