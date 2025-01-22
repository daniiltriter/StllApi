using Microsoft.EntityFrameworkCore;
using Stll.Infrastructure.Configurations;
using Stll.Types;

namespace Stll.Infrastructure;

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