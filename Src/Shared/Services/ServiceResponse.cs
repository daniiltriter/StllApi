namespace Stll.Shared.Services;

public abstract class ServiceResponse<TResult>
{
    public bool Processed { get; set; }
    public string ErrorMessage { get; set; }
    protected TResult Result { get; set; }
}