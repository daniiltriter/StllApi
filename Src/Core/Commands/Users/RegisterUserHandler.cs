using System.Text.RegularExpressions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stll.Core.Domain;
using Stll.Core.Services;
using Stll.Core.Types;

namespace Stll.Core.Commands.Users;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
{
    private IPasswordHasher _hasher;
    private readonly ApplicationContext _domainContext;
    
    public RegisterUserHandler(IPasswordHasher hasher, ApplicationContext domainContext)
    {
        _domainContext = domainContext;
        _hasher = hasher;
    }
    
    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var nameUnfilled = string.IsNullOrWhiteSpace(request.Name);
        if (nameUnfilled)
        {
            return Unit.Value;
        }

        var nameLengthInvalid = request.Name.Length < 6 && request.Name.Length > 32;
        if (nameLengthInvalid)
        {
            return Unit.Value;
        }

        var userIsExists = await _domainContext.Users.AnyAsync(u => u.Name == request.Name,
            cancellationToken);
        if (userIsExists)
        {
            return Unit.Value;
        }

        var passwordUnfilled = string.IsNullOrWhiteSpace(request.Password);
        if (passwordUnfilled)
        {
            return Unit.Value;
        }

        var passwordLengthInvalid = request.Password.Length < 6 && request.Password.Length > 128;
        if (passwordLengthInvalid)
        {
            return Unit.Value;
        }

        const string securityPattern = @"^(?=.*[!@#$%^&*(),.?"":{}|<>])(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$";
        var passwordIsUnsecure = !Regex.IsMatch(request.Password, securityPattern);
        if (passwordIsUnsecure)
        {
            return Unit.Value;
        }
        
        var hashedPassword = _hasher.Crypt(request.Password);
        var user = new User
        {
            Name = request.Name,
            Password = hashedPassword,
            Role = "Usual"
        };

        await _domainContext.Users.AddAsync(user, cancellationToken);
        await _domainContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}