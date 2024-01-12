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
        Services.AddScoped<IContextProvider<TEntity>, ContextProvider<TEntity, TContext>>();
        return this;
    }

    internal static DomainServiceBuilder<TContext> Initialize(IServiceCollection services) => new(services);
}