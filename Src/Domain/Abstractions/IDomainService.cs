namespace Stll.Domain.Abstractions;

public interface IDomainService
{
    IContextProvider<TEntity> GetContextFor<TEntity>() where TEntity : class, IEntity;
}