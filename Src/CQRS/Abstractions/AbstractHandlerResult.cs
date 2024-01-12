namespace Stll.WebAPI.Commands;

public abstract class AbstractHandlerResult
{
    public string Error { get; set; }
    public bool Processed { get; set; }
}