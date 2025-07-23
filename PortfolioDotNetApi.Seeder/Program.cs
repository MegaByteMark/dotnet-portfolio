using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortfolioDotNetApi.Domain.Entities;
using PortfolioDotNetApi.Infrastructure.Data;

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

        var employeeFaker = new Faker<Employee>();
        employeeFaker.RuleFor(p => p.FirstName, f => f.Name.FirstName());
        employeeFaker.RuleFor(p => p.LastName, f => f.Name.LastName());
        employeeFaker.RuleFor(p => p.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)));
        employeeFaker.RuleFor(p => p.Email, f => f.Internet.Email());
        employeeFaker.RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber());
        employeeFaker.RuleFor(p => p.Address, f => f.Address.FullAddress());
        employeeFaker.RuleFor(p => p.Position, f => f.Name.JobTitle());
        employeeFaker.RuleFor(p => p.Salary, f => f.Finance.Amount(30000, 150000));
        employeeFaker.RuleFor(p => p.HireDate, f => f.Date.Past(30, DateTime.Now.AddYears(-2)));
        employeeFaker.RuleFor(p => p.Department, f => f.Name.JobArea());
        employeeFaker.RuleFor(p => p.EmployeeId, f => f.Random.AlphaNumeric(6));

        var employeeList = employeeFaker.Generate(100);
        context.Employees.Load();
        context.Employees.RemoveRange(context.Employees);
        context.Employees.AddRange(employeeList);
        context.SaveChanges();

        var employeeIdList = employeeList.Select(e => e.Id).ToList();

        var customerFaker = new Faker<Customer>();
        customerFaker.RuleFor(p => p.FirstName, f => f.Name.FirstName());
        customerFaker.RuleFor(p => p.LastName, f => f.Name.LastName());
        customerFaker.RuleFor(p => p.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)));
        customerFaker.RuleFor(p => p.Email, f => f.Internet.Email());
        customerFaker.RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber());
        customerFaker.RuleFor(p => p.Address, f => f.Address.FullAddress());
        customerFaker.RuleFor(p => p.LoyaltyCardNo, f => f.Random.AlphaNumeric(10));

        var customerList = customerFaker.Generate(10);

        context.Customers.Load();
        context.Customers.RemoveRange(context.Customers);
        context.Customers.AddRange(customerList);
        context.SaveChanges();

        var customerIdList = customerList.Select(c => c.Id).ToList();

        var productFaker = new Faker<Product>();
        productFaker.RuleFor(p => p.Name, f => f.Commerce.ProductName());
        productFaker.RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
        productFaker.RuleFor(p => p.Price, f => f.Finance.Amount(1, 1000));

        var productList = productFaker.Generate(50);
        context.Products.Load();
        context.Products.RemoveRange(context.Products);
        context.Products.AddRange(productList);
        context.SaveChanges();

        var productIdList = productList.Select(p => p.Id!.Value).ToList();

        var orderFaker = new Faker<Order>();
        orderFaker.RuleFor(p => p.CustomerId, f => f.PickRandom(customerIdList));
        orderFaker.RuleFor(p => p.OrderDate, f => f.Date.Past(1, DateTime.Now));
        orderFaker.RuleFor(p => p.Status, f => f.Random.Enum<OrderStatus>());
        orderFaker.RuleFor(p => p.Items, f => f.Make(
            f.Random.Int(1, 5),
            () => new OrderItem
            {
                OrderId = f.IndexFaker,
                ProductId = f.PickRandom(productIdList),
                Quantity = f.Random.Int(1, 10)
            }));

        var orderList = orderFaker.Generate(20);
        context.Orders.Load();
        context.Orders.RemoveRange(context.Orders);

        // Ensure there are no duplicate OrderItems
        foreach (var order in orderList)
        {
            var uniqueItems = order.Items
                .GroupBy(item => new { item.OrderId, item.ProductId })
                .Select(group => group.First())
                .ToList();  

            order.Items = uniqueItems;
        }

        context.Orders.AddRange(orderList);

        context.SaveChanges();
    }
}