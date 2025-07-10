using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories;
using PortfolioDotNetApi.Infrastructure.DbContext;
using PortfolioDotNetApi.Models;

namespace PortfolioDotNetApi.Infrastructure.Repositories;

public class OrderRepository: BaseAuditableRepository<Order, PortfolioDotNetApiDbContext>
{
    public OrderRepository(PortfolioDotNetApiDbContext context) : base(context)
    {
    }
}