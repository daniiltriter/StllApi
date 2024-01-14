namespace Stll.CQRS.Abstractions;

internal abstract class AbstractBaseHandler
{
    public abstract Task<object> Handle();
}