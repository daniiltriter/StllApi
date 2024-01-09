using System.Security.Claims;

namespace Stll.Core.Types;

public class JwtData
{
    public ClaimsIdentity Subject { get; set; }
}