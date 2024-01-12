using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stll.Domain.Abstractions;

namespace Stll.Domain.Services;

public class ContextProvider<TEntity, TContext> : IContextProvider<TEntity>
    where TEntity : class, IEntity
    where TContext: DbContext
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ContextProvider(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<ulong> CreateAsync(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentException(null, nameof(TEntity));
        }
        
        using var scope = _scopeFactory.CreateScope();
        
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        var newEntity = await context.Set<TEntity>().AddAsync(entity);

        await context.SaveChangesAsync();

        return newEntity.Entity.Id;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentException(null, nameof(TEntity));
        }

        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        
        context.Set<TEntity>().Update(entity);
        var affectedCount = await context.SaveChangesAsync();
        
        return affectedCount > 0;
    }

    public async Task<bool> RemoveAsync(ulong id)
    {
        if (id == 0)
        {
            throw new ArgumentException(null, nameof(id));
        }

        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        var dbSet = context.Set<TEntity>();

        var entity = await dbSet.FirstAsync(e => e.Id == id);
        var removed = dbSet.Remove(entity);
        await context.SaveChangesAsync();

        return removed.State == EntityState.Deleted;
    }

    public async Task<TEntity> FindAsync(ulong id)
    {
        if (id == 0)
        {
            throw new ArgumentException(null, nameof(id));
        }
        
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        
        var entity = await context.Set<TEntity>().FindAsync(id);
        return entity;
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
    {
        if (filter == null)
        {
            throw new ArgumentException(null, nameof(filter));
        }
        
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        
        var entity = await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
    {
        if (filter == null)
        {
            throw new ArgumentException(null, nameof(filter));
        }
        
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        
        return await context.Set<TEntity>().AnyAsync(filter);
    }
}