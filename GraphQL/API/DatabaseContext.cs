using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Hero> Heroes { get; set; }
}
