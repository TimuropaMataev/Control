using Control.Objects;
using Microsoft.EntityFrameworkCore;

namespace Control.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=controldata");
    }
}