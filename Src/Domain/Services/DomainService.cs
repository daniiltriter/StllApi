using Microsoft.Extensions.DependencyInjection;
using Stll.Domain.Abstractions;

namespace Stll.Domain.Services;

public class DomainService : IDomainService
{
    private readonly IServiceProvider _services;
    public DomainService(IServiceProvider services)
    {
        _services = services;
    }
    public IContextProvider<TEntity> GetContextFor<TEntity>() where TEntity : class, IEntity
    {
        return _services.GetService<IContextProvider<TEntity>>();
    }   

    public IMemoryProvider<TEntity> GetCacheFor<TEntity>() where TEntity : class, IEntity
    {
        return _services.GetService<IMemoryProvider<TEntity>>();
    }
}