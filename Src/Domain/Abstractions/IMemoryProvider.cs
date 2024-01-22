namespace Stll.Domain.Abstractions;

public interface IMemoryProvider<TEntity> where TEntity : class, IEntity
{
    Task<TEntity> TakeAsync(ulong id);
    Task PutAsync(TEntity entity);
}