using Domain;
using HotChocolate.Types;

namespace Application.GraphQL.TypeDescriptor
{
    public class SuperHeroDescriptor : ObjectType<SuperHero>
    {
        protected override void Configure(IObjectTypeDescriptor<SuperHero> descriptor)
        {
            descriptor.Description("Defines some of the worlds most powerful!");

            descriptor.Field(p => p.Name)
                      .Description("Their civie name, but off the record.");

            descriptor.Field(p => p.Alias)
                      .Description("A pseudonym to protect those they hold dear.");
        }
    }
}