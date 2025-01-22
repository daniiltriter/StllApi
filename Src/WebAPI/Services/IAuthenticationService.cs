using System.Security.Claims;

namespace Stll.WebAPI.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(string name, string password);
}