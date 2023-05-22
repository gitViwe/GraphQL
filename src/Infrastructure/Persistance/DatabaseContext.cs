using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
        OverwatchSuperHeroes = Set<OverwatchSuperHero>();
        OverwatchMaps = Set<OverwatchCombatMap>();
        OverwatchDeployments = Set<OverwatchDeployment>();
    }

    public DbSet<OverwatchSuperHero> OverwatchSuperHeroes { get; set; }
    public DbSet<OverwatchCombatMap> OverwatchMaps { get; set; }
    public DbSet<OverwatchDeployment> OverwatchDeployments { get; set; }
}
