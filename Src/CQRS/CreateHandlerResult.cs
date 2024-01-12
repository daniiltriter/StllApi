namespace Stll.WebAPI.Commands;

public class CreateHandlerResult : AbstractHandlerResult
{
    public ulong Id { get; set; }
    
    public static CreateHandlerResult Failed(string error) => new()
    {
        Processed = false,
        Error = error
    };

    public static CreateHandlerResult Success(ulong id) => new()
    {
        Id = id,
        Processed = true,
        Error = null
    };
}