using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Models;
using IntraDotNet.EntityFrameworkCore.Relational;

namespace PortfolioDotNetApi.Repos.DbContext;

public class PortfolioDotNetApiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public PortfolioDotNetApiDbContext(DbContextOptions<PortfolioDotNetApiDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Developer>()
            .HasOne( d => d.Rating)
            .WithMany(r => r.Developers)
            .HasForeignKey(d => d.RatingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.UseAuditable<Rating>();
        modelBuilder.UseAuditable<Developer>();

        modelBuilder.UseOptimisticConcurrency<Rating>();
        modelBuilder.UseOptimisticConcurrency<Developer>();
    }
}
