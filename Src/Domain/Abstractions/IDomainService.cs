namespace Stll.Domain.Abstractions;

public interface IDomainService
{
    IContextProvider<TEntity> GetContextFor<TEntity>() where TEntity : class, IEntity;
    IMemoryProvider<TEntity> GetCacheFor<TEntity>() where TEntity : class, IEntity;
}