using System.Security.Claims;

namespace Stll.Shared.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(string name, string password);
}