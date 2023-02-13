using Application.GraphQL.Middleware;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Application.GraphQL.Attribute;

public class ResolveCurrentUserAttribute : ObjectFieldDescriptorAttribute
{
    public ResolveCurrentUserAttribute([CallerLineNumber] int order = 0) => Order = order;
    protected override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.Use<CurrentUserMiddleware>();
    }
}
