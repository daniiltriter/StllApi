namespace Stll.CQRS.Abstractions;

public abstract class AbstractHandlerResult
{
    public string Error { get; set; }
    public bool Processed { get; set; }
}