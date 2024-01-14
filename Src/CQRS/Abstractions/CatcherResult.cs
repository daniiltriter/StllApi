namespace Stll.WebAPI.Commands;

public abstract class CatcherResult
{
    public string ErrorMessage { get; set; }
    public bool HasError { get; set; }
}