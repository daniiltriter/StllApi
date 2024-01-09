using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stll.Core.Services;
using Stll.Domain.Internal;
using Stll.Types;
using Stll.Types.Variables;

namespace Stll.Core.Commands.Users;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, CreatedHandlerResult>
{
    private readonly IPasswordHasher _hasher;
    private readonly ApplicationContext _domainContext;
    private readonly IMapper _mapper;
    
    public RegisterUserHandler(IPasswordHasher hasher, ApplicationContext domainContext, 
        IMapper mapper)
    {
        _hasher = hasher;
        _domainContext = domainContext;
        _mapper = mapper;
    }
    
    public async Task<CreatedHandlerResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var nameUnfilled = string.IsNullOrWhiteSpace(request.Name);
        if (nameUnfilled)
        {
            return CreatedHandlerResult.Failed(UsersErrorCodes.NAME_IS_EMPTY);
        }
        
        var nameLengthInvalid = request.Name.Length < 6 || request.Name.Length > 32;
        if (nameLengthInvalid)
        {
            return CreatedHandlerResult.Failed(UsersErrorCodes.NAME_INVALID_LENGTH);
        }
        
        var userIsExists = await _domainContext.Users.AnyAsync(u => u.Name == request.Name,
            cancellationToken);
        if (userIsExists)
        {
            return CreatedHandlerResult.Failed(UsersErrorCodes.USER_ALREADY_EXISTS);
        }

        var passwordUnfilled = string.IsNullOrWhiteSpace(request.Password);
        if (passwordUnfilled)
        {
            return CreatedHandlerResult.Failed(UsersErrorCodes.PASSWORD_IS_EMPTY);
        }

        var passwordLengthInvalid = request.Password.Length < 6 && request.Password.Length > 128;
        if (passwordLengthInvalid)
        {
            return CreatedHandlerResult.Failed(UsersErrorCodes.PASSWORD_INVALID_LENGTH);
        }

        var passwordIsUnsecure = !Regex.IsMatch(request.Password, RegexPatterns.SECURED_PASSWORD);
        if (passwordIsUnsecure)
        {
            return CreatedHandlerResult.Failed(UsersErrorCodes.PASSWORD_UNSECURE);
        }
        
        var user = _mapper.Map<User>(request);
        user.Password = _hasher.Crypt(request.Password);

        var newEntity = await _domainContext.Users.AddAsync(user, cancellationToken);
        var entityId = newEntity.Entity.Id; 
        
        await _domainContext.SaveChangesAsync(cancellationToken);
        return CreatedHandlerResult.Success(entityId);
    }
}