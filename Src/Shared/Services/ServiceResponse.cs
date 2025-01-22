namespace Stll.Shared.Services;

public class ServiceResponse<TResult>
{
    public bool Processed { get; set; }
    public string ErrorMessage { get; set; }
    public TResult Result { get; set; }

    public static ServiceResponse<TResult> Success(TResult result) => new()
    {
        Processed = true,
        ErrorMessage = null,
        Result = result
    };
    
    public static ServiceResponse<TResult> Failed(string error) => new()
    {
        Processed = true,
        ErrorMessage = error,
        Result = default
    };
}