using IntraDotNet.EntityFrameworkCore.Infrastructure.Relational;
using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Models;

namespace PortfolioDotNetApi.Repos.DbContext;

public class PortfolioDotNetApiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Person> Persons { get; set; }

    public PortfolioDotNetApiDbContext(DbContextOptions<PortfolioDotNetApiDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Table-per-Type (TPT) inheritance
        modelBuilder.Entity<Person>().ToTable("Persons");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Employee>().ToTable("Employees");

        //Configure composite keys
        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });

        //Set precisions
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2); // 18 total digits, 2 decimal places

        modelBuilder.Entity<Employee>()
        .Property(e => e.Salary)
            .HasPrecision(18, 2); // 18 total digits, 2 decimal places

        modelBuilder.UseAuditable<Customer>();
        modelBuilder.UseAuditable<Employee>();
        modelBuilder.UseAuditable<Order>();
        modelBuilder.UseAuditable<OrderItem>();
        modelBuilder.UseAuditable<Product>();

        modelBuilder.UseOptimisticConcurrency<Customer>();
        modelBuilder.UseOptimisticConcurrency<Employee>();
        modelBuilder.UseOptimisticConcurrency<Order>();
        modelBuilder.UseOptimisticConcurrency<OrderItem>();
        modelBuilder.UseOptimisticConcurrency<Product>();
    }
}
