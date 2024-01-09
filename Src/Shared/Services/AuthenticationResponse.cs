using System.Security.Claims;

namespace Stll.Shared.Services;

public class AuthenticationResponse : ServiceResponse<ClaimsIdentity>
{
    public ClaimsIdentity Identity => Result;

    public static AuthenticationResponse Success(ClaimsIdentity identity) => new()
    {
        Result = identity,
        Processed = true,
        ErrorMessage = null
    };
    
    public static AuthenticationResponse Failed(string error) => new()
    {
        Result = null,
        Processed = false,
        ErrorMessage = error
    };
}