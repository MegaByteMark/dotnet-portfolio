using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Infrastructure.DbContext;
using PortfolioDotNetApi.Infrastructure.Repositories;

namespace PortfolioDotNetApi.Infrastructure.UnitOfWork;

public class CustomerUnitOfWork(IDbContextFactory<PortfolioDotNetApiDbContext> contextFactory) : UnitOfWork<PortfolioDotNetApiDbContext>(contextFactory)
{
    protected override TRepository CreateRepository<TRepository>()
    {
        return typeof(TRepository).Name switch
        {
            nameof(ProductRepository) => (TRepository)(object)new ProductRepository(Context),
            _ => throw new NotSupportedException($"Repository type {typeof(TRepository).Name} is not supported")
        };
    }
}