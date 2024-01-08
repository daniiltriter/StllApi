using System.Security.Claims;

namespace Stll.Core.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(string name, string password);
}