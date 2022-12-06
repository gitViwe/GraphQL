using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
        Heroes = Set<SuperHero>();
    }

    public DbSet<SuperHero> Heroes { get; set; }
}
