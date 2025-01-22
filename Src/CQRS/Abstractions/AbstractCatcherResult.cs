namespace Stll.CQRS.Abstractions;

public abstract class AbstractCatcherResult
{
    public string ErrorMessage { get; set; }
    public bool Processed { get; set; }
}