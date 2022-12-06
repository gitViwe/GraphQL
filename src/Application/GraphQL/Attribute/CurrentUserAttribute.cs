using HotChocolate;

namespace Application.GraphQL.Attribute;

public class CurrentUserAttribute : GlobalStateAttribute
{
    public CurrentUserAttribute()
        : base("CurrentUser") { }
}
