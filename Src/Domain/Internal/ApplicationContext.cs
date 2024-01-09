using Microsoft.EntityFrameworkCore;
using Stll.Domain.Internal.Configurations;
using Stll.Types;

namespace Stll.Domain.Internal;

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