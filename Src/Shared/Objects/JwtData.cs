using System.Security.Claims;

namespace Stll.Shared.Types;

public class JwtData
{
    public ClaimsIdentity Subject { get; set; }
}