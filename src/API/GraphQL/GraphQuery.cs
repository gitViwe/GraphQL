using API.Model;

namespace API.GraphQL;

/// <summary>
/// Represents the graphQL queries
/// </summary>
[GraphQLDescription("The base query class to encapsulate the GraphQL queries")]
public class GraphQuery
{
    /// <summary>
    /// Gets the hero objects
    /// </summary>
    /// <param name="context">Tha database context used</param>
    /// <returns>A queryable hero collection</returns>
    [GraphQLDescription("Gets the queryable heroes.")]
    public IQueryable<Hero> GetHeroes([Service] DatabaseContext context)
    {
        return context.Heroes;
    }
}
