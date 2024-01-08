using System.Security.Claims;
using Stll.Core.Types;

namespace Stll.Core.Services;

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