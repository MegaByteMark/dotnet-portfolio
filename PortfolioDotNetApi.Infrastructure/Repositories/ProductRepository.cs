using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories;
using PortfolioDotNetApi.Domain.Entities;
using PortfolioDotNetApi.Infrastructure.Data;

namespace PortfolioDotNetApi.Infrastructure.Repositories;

public class ProductRepository(PortfolioDotNetApiDbContext context) : BaseAuditableRepository<Product, PortfolioDotNetApiDbContext>(context)
{
}