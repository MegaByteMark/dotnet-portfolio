using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Infrastructure.Data;
using PortfolioDotNetApi.Infrastructure.Repositories;

namespace PortfolioDotNetApi.Infrastructure.UnitOfWork;

public class OrderUnitOfWork(IDbContextFactory<PortfolioDotNetApiDbContext> contextFactory) : UnitOfWork<PortfolioDotNetApiDbContext>(contextFactory)
{
    protected override TRepository CreateRepository<TRepository>()
    {
        return typeof(TRepository).Name switch
        {
            nameof(OrderRepository) => (TRepository)(object)new OrderRepository(Context),
            _ => throw new NotSupportedException($"Repository type {typeof(TRepository).Name} is not supported")
        };
    }
}