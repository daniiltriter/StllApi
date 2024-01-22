using Microsoft.EntityFrameworkCore;
using Stll.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Stll.Domain.Services;

namespace Stll.Domain.IoC;

public class DomainServiceBuilder<TContext> where TContext: DbContext
{
    public IServiceCollection Services { get; }
    private DomainServiceBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public DomainServiceBuilder<TContext> AddEntity<TEntity>() where TEntity: class, IEntity
    {
        Services.AddTransient<IContextProvider<TEntity>, ContextProvider<TEntity, TContext>>();
        return this;
    }
    
    public DomainServiceBuilder<TContext> InMemory<TEntity>() where TEntity: class, IEntity
    {
        Services.AddTransient<IMemoryProvider<TEntity>, MemoryProvider<TEntity>>();
        return this;
    }

    internal static DomainServiceBuilder<TContext> Initialize(IServiceCollection services) => new(services);
}