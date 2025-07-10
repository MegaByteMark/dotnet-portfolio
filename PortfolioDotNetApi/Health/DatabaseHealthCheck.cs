using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PortfolioDotNetApi.Infrastructure.DbContext;

namespace PortfolioDotNetApi.Health;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly PortfolioDotNetApiDbContext _dbContext;

    public DatabaseHealthCheck(PortfolioDotNetApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try {
            _dbContext.Database.ExecuteSqlRaw("SELECT 1");
            return Task.FromResult(HealthCheckResult.Healthy());
        }
        catch (Exception ex)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy(ex.Message, ex));
        }
    }
}
