namespace Stll.Core.Commands;

public class CreatedHandlerResult : AbstractHandlerResult
{
    public ulong Id { get; set; }
    
    public static CreatedHandlerResult Failed(string error) => new()
    {
        Processed = false,
        Error = error
    };

    public static CreatedHandlerResult Success(ulong id) => new()
    {
        Id = id,
        Processed = true,
        Error = null
    };
}