using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories;
using PortfolioDotNetApi.Domain.Entities;
using PortfolioDotNetApi.Infrastructure.Data;

namespace PortfolioDotNetApi.Infrastructure.Repositories;

public class OrderRepository(PortfolioDotNetApiDbContext context) : BaseAuditableRepository<Order, PortfolioDotNetApiDbContext>(context)
{
}