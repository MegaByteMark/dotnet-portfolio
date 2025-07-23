using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories;
using PortfolioDotNetApi.Domain.Entities;
using PortfolioDotNetApi.Infrastructure.Data;

namespace PortfolioDotNetApi.Infrastructure.Repositories;

public class CustomerRepository(PortfolioDotNetApiDbContext dbContext) : BaseAuditableRepository<Customer, PortfolioDotNetApiDbContext>(dbContext)
{
}
