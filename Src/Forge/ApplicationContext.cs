using Microsoft.EntityFrameworkCore;
using Stll.Forge.Configurations;
using Stll.Types;

namespace Stll.Forge;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserEntityConfiguration());
    }
}