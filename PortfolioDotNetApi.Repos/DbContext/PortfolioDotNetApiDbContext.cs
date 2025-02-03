using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Models;
using IntraDotNet.EntityFrameworkCore.Optimizations.Relational;

namespace PortfolioDotNetApi.Repos.DbContext;

public class PortfolioDotNetApiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<DeveloperRating> DeveloperRatings { get; set; }

    public PortfolioDotNetApiDbContext(DbContextOptions<PortfolioDotNetApiDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeveloperRating>()
            .HasKey(dr => new { dr.DeveloperId, dr.RatingId });

        modelBuilder.Entity<DeveloperRating>()
            .HasOne(dr => dr.Developer)
            .WithMany(d => d.DeveloperRatings)
            .HasForeignKey(dr => dr.DeveloperId);

        modelBuilder.Entity<DeveloperRating>()
            .HasOne(dr => dr.Rating)
            .WithMany(r => r.DeveloperRatings)
            .HasForeignKey(dr => dr.RatingId);

        modelBuilder.UseAuditable<Rating>();
        modelBuilder.UseAuditable<DeveloperRating>();
        modelBuilder.UseAuditable<Developer>();

        modelBuilder.UseOptimisticConcurrency<Rating>();
        modelBuilder.UseOptimisticConcurrency<DeveloperRating>();
        modelBuilder.UseOptimisticConcurrency<Developer>();
    }
}
