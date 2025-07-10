using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories;
using PortfolioDotNetApi.Infrastructure.DbContext;

namespace PortfolioDotNetApi.Infrastructure.Repositories;

public class CustomerRepository: BaseAuditableRepository<Models.Customer, PortfolioDotNetApiDbContext>
{
    public CustomerRepository(PortfolioDotNetApiDbContext dbContext) : base(dbContext)
    {
    }
}
