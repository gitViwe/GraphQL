namespace API.Model;

public class HeroDescriptor : ObjectType<Hero>
{
    protected override void Configure(IObjectTypeDescriptor<Hero> descriptor)
    {
        descriptor.Description("Defines some of the worlds most powerful!");

        descriptor.Field(p => p.Alias)
            .Description("A pseudonym to protect those they hold dear.");

        descriptor.Field(p => p.Avatar)
            .Description("The link to the only photo we have on record.");

        descriptor.Field(p => p.)
            .Description("A pseudonym to protect those they hold dear.");
    }
}
