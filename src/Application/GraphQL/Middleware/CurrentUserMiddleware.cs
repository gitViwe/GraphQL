using Application.GraphQL.ContextData;
using HotChocolate.Resolvers;
using System.Security.Claims;

namespace Application.GraphQL.Middleware;

public class CurrentUserMiddleware
{
    private readonly FieldDelegate _next;

    public CurrentUserMiddleware(FieldDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(IMiddlewareContext context)
    {
        var claimsPrincipal = context.ContextData["ClaimsPrincipal"] as ClaimsPrincipal;
        var user = new CurrentUser { UserId = claimsPrincipal?.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty };
        context.ContextData.Add(nameof(CurrentUser), user);

        await _next(context);
    }
}
