using Microsoft.EntityFrameworkCore;
using Stll.Core.Domain.Configurations;
using Stll.Core.Types;

namespace Stll.Core.Domain;

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