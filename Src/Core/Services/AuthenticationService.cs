using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Stll.Core.Domain;
using Stll.Core.Variables;

namespace Stll.Core.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly ApplicationContext _domain;
    public AuthenticationService(ApplicationContext domain)
    {
        _domain = domain;
    }
    public async Task<AuthenticationResponse> AuthenticateAsync(string name, string password)
    {
        var user = await _domain.Users.FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        if (user is null)
        {
            return AuthenticationResponse.Failed(AuthenticationErrorCodes.InvalidCredentials);
        }

        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.Name),
            new(ClaimsIdentity.DefaultRoleClaimType, user.Role)
        };

        var identity = new ClaimsIdentity(claims);

        return AuthenticationResponse.Success(identity);
    }
}