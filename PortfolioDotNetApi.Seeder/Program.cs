using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortfolioDotNetApi.Models;
using PortfolioDotNetApi.Repos.DbContext;

internal class Program
{
    private static void Main(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        DbContextOptionsBuilder<PortfolioDotNetApiDbContext> optionsBuilder = new DbContextOptionsBuilder<PortfolioDotNetApiDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        using PortfolioDotNetApiDbContext context = new(optionsBuilder.Options);

        context.Database.EnsureCreated();

        List<Rating> ratings = new()
        {
            new Rating { Id = Guid.Parse("6c0b85da-b65b-4652-80fd-e91e4a378e29"), Score = 1},
            new Rating { Id = Guid.Parse("4bf617e5-b335-49a8-a728-a73f6542e1f6"), Score = 2 },
            new Rating { Id = Guid.Parse("9340f2db-20d3-4219-b95c-4a03390fa05f"), Score = 3 },
            new Rating { Id = Guid.Parse("59538dfe-e42b-45e1-9b77-4fb161615790"), Score = 4 },
            new Rating { Id = Guid.Parse("6f92e18c-5372-4928-83ed-03f11887f794"), Score = 5 }
        };

        Faker<Developer> faker = new Faker<Developer>();
        faker.RuleFor(d => d.Id, f => Guid.NewGuid());
        faker.RuleFor(d => d.FirstName, f => f.Name.FirstName());
        faker.RuleFor(d => d.LastName, f => f.Name.LastName());
        faker.RuleFor(d => d.Email, f => f.Internet.Email());

        var developers = faker.Generate(10);

        context.Developers.Load();
        context.Developers.RemoveRange(context.Developers);
        context.Developers.AddRange(developers);

        context.Ratings.Load();
        context.Ratings.RemoveRange(context.Ratings);
        context.Ratings.AddRange(ratings);

        context.SaveChanges();
    }
}