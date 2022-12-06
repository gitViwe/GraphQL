using HotChocolate.Types;

namespace Application.GraphQL.TypeDescriptor;

public record SuperHeroOutput(long Id, string Name, string Alias);

public class SuperHeroOutputDescriptor : ObjectType<SuperHeroOutput>
{
    protected override void Configure(IObjectTypeDescriptor<SuperHeroOutput> descriptor)
    {
        descriptor.Description("Represents the input to add for a super hero.");

        descriptor.Field(p => p.Name)
                  .Description("Their civie name, but off the record.");

        descriptor.Field(p => p.Alias)
                  .Description("A pseudonym to protect those they hold dear.");
    }
}
