using API.Model;

namespace API.GraphQL;

public class Query
{
    public IQueryable<Hero> GetHeroes([Service] DatabaseContext context)
    {
        return context.Heroes;
    }
}
