using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories;
using PortfolioDotNetApi.Infrastructure.DbContext;
using PortfolioDotNetApi.Models;

namespace PortfolioDotNetApi.Infrastructure.Repositories;

public class ProductRepository: BaseAuditableRepository<Product, PortfolioDotNetApiDbContext>
{
    public ProductRepository(PortfolioDotNetApiDbContext context) : base(context)
    {
    }
}
