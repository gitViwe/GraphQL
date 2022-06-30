using API.Model;

namespace API.GraphQL;

public class Query
{
    [GraphQLDescription("Gets the queryable heroes.")]
    public IQueryable<Hero> GetHeroes([Service] DatabaseContext context)
    {
        return context.Heroes;
    }
}
