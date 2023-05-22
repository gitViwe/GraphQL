using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extension;

internal static class IQueryableExtension
{
    /// <summary>
    /// Applies the includes method to the navigation properties on <see cref="OverwatchSuperHero"/> to allow for schema traversing.
    /// </summary>
    /// <param name="query"></param>
    /// <returns>An <see cref="IQueryable{OverwatchSuperHero}"/> where the type is <see cref="OverwatchSuperHero"/></returns>
    public static IQueryable<OverwatchSuperHero> ApplyDefaultIncludes(this IQueryable<OverwatchSuperHero> query)
    {
        return query.Include(x => x.Detail)
                    .Include(x => x.Detail.Abilities)
                    .Include(x => x.Detail.Hitpoints)
                    .Include(x => x.Detail.Role)
                    .Include(x => x.Detail.Story)
                    .Include(x => x.Detail.Story.Chapters);
    }
}
