using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories;
using PortfolioDotNetApi.Infrastructure.DbContext;
using PortfolioDotNetApi.Models;

namespace PortfolioDotNetApi.Infrastructure.Repositories;

public class EmployeeRepository: BaseAuditableRepository<Employee, PortfolioDotNetApiDbContext>
{
    public EmployeeRepository(PortfolioDotNetApiDbContext context) : base(context)
    {
    }
}
