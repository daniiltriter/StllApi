using System.Security.Claims;
using Stll.Domain.Abstractions;
using Stll.Shared.Services;
using Stll.Types;
using Stll.Types.Variables;


namespace Stll.WebAPI.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IDomainService _domain;
    private readonly IPasswordHasher _hasher;
    public AuthenticationService(IPasswordHasher hasher, IDomainService domain)
    {
        _domain = domain;
        _hasher = hasher;
    }
    public async Task<AuthenticationResponse> AuthenticateAsync(string name, string password)
    {
        // TODO: add missed checks (name, password length and empty)
        // TODO: add Exists method to IDomainService
        var user = await _domain.GetContextFor<User>().FindAsync(u => u.Name == name);
        if (user == null)
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