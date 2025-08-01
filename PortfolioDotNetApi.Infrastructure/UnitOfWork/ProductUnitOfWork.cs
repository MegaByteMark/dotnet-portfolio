using IntraDotNet.EntityFrameworkCore.Infrastructure.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PortfolioDotNetApi.Infrastructure.Data;
using PortfolioDotNetApi.Infrastructure.Repositories;

namespace PortfolioDotNetApi.Infrastructure.UnitOfWork;

public class ProductUnitOfWork: UnitOfWork<PortfolioDotNetApiDbContext>
{
    public ProductUnitOfWork(IDbContextFactory<PortfolioDotNetApiDbContext> contextFactory) : base(contextFactory)
    {
    }

    protected override TRepository CreateRepository<TRepository>()
    {
        return typeof(TRepository).Name switch
        {
            nameof(ProductRepository) => (TRepository)(object)new ProductRepository(Context),
            _ => throw new NotSupportedException($"Repository type {typeof(TRepository).Name} is not supported")
        };
    }
}