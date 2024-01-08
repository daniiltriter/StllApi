using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Stll.Core.Domain;
using Stll.Core.Variables;

namespace Stll.Core.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly ApplicationContext _domain;
    private readonly IPasswordHasher _hasher;
    public AuthenticationService(IPasswordHasher hasher, ApplicationContext domain)
    {
        _domain = domain;
        _hasher = hasher;
    }
    public async Task<AuthenticationResponse> AuthenticateAsync(string name, string password)
    {
        var user = await _domain.Users.FirstOrDefaultAsync(u => u.Name == name);
        if (user is null)
        {
            return AuthenticationResponse.Failed(AuthenticationErrorCodes.INVALID_CREDENTIALS);
        }

        var passwordVerified = _hasher.Verify(password, user.Password);
        if (!passwordVerified)
        {
            return AuthenticationResponse.Failed(AuthenticationErrorCodes.INVALID_CREDENTIALS);
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