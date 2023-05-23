using Domain;
using HotChocolate.Types;

namespace Application.GraphQL.TypeDescriptor;

public class OverwatchSuperHeroDescriptor : ObjectType<OverwatchSuperHero>
{
    protected override void Configure(IObjectTypeDescriptor<OverwatchSuperHero> descriptor)
    {
        descriptor.Description("Defines some of the worlds most powerful!");

        descriptor.Field(p => p.Detail)
                  .Description("This information is highly classified.");
    }
}
