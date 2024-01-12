using System.Linq.Expressions;

namespace Stll.Domain.Abstractions;

public interface IContextProvider<TEntity> where TEntity : class, IEntity
{
    Task<ulong> CreateAsync(TEntity entity);
    
    Task<bool> UpdateAsync(TEntity entity);
    
    Task<bool> RemoveAsync(ulong id);
    
    Task<TEntity> FindAsync(ulong id);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
}