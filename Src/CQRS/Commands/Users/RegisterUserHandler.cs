using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stll.Core.Commands;
using Stll.Domain.Internal;
using Stll.Shared.Services;
using Stll.Types;
using Stll.Types.Variables;

namespace Stll.CQRS.Commands.Users;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, CreateHandlerResult>
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
    
    public async Task<CreateHandlerResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var nameUnfilled = string.IsNullOrWhiteSpace(request.Name);
        if (nameUnfilled)
        {
            return CreateHandlerResult.Failed(UsersErrorCodes.NAME_IS_EMPTY);
        }
        
        var nameLengthInvalid = request.Name.Length < 6 || request.Name.Length > 32;
        if (nameLengthInvalid)
        {
            return CreateHandlerResult.Failed(UsersErrorCodes.NAME_INVALID_LENGTH);
        }
        
        var userIsExists = await _domainContext.Users.AnyAsync(u => u.Name == request.Name,
            cancellationToken);
        if (userIsExists)
        {
            return CreateHandlerResult.Failed(UsersErrorCodes.USER_ALREADY_EXISTS);
        }

        var passwordUnfilled = string.IsNullOrWhiteSpace(request.Password);
        if (passwordUnfilled)
        {
            return CreateHandlerResult.Failed(UsersErrorCodes.PASSWORD_IS_EMPTY);
        }

        var passwordLengthInvalid = request.Password.Length < 6 || request.Password.Length > 128;
        if (passwordLengthInvalid)
        {
            return CreateHandlerResult.Failed(UsersErrorCodes.PASSWORD_INVALID_LENGTH);
        }

        var passwordIsUnsecure = !Regex.IsMatch(request.Password, RegexPatterns.SECURED_PASSWORD);
        if (passwordIsUnsecure)
        {
            return CreateHandlerResult.Failed(UsersErrorCodes.PASSWORD_UNSECURE);
        }
        
        var user = _mapper.Map<User>(request);
        var hashedPassword = _hasher.Crypt(request.Password);
        user.Password = hashedPassword;

        var newEntity = await _domainContext.Users.AddAsync(user, cancellationToken);
        var entityId = newEntity.Entity.Id; 
        
        await _domainContext.SaveChangesAsync(cancellationToken);
        return CreateHandlerResult.Success(entityId);
    }
}