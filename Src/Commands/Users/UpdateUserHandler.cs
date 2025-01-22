using System.Text.RegularExpressions;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Results;
using Stll.Domain.Abstractions;
using Stll.Shared.Services;
using Stll.Types;
using Stll.Types.Variables;
using Stll.WebAPI.Commands;

namespace Stll.Commands.Users;

public class UpdateUserHandler : IExecutorHandler<UpdateUserCommand, UpdateHandlerResult>
{
    private readonly IDomainService _domain;
    private readonly IPasswordHasher _hasher;
    
    public UpdateUserHandler(IDomainService domain, IPasswordHasher hasher)
    {
        _domain = domain;
        _hasher = hasher;
    }
    public async Task<UpdateHandlerResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == 0)
        {
            return UpdateHandlerResult.Failed(UsersErrorCodes.NOT_FOUND);
        }

        var user = await _domain.GetContextFor<User>().FindAsync(request.Id);
        if (user == null)
        {
            return UpdateHandlerResult.Failed(UsersErrorCodes.NOT_FOUND);
        }

        var isNameUpdating = !string.IsNullOrWhiteSpace(request.Name) && !request.Name.Equals(user.Name);
        if (isNameUpdating)
        {
            var nameStepResult = await ValidateNameStepAsync(request);
            if (!nameStepResult.Processed)
            {
                return UpdateHandlerResult.Failed(nameStepResult.Error);
            }
            user.Name = request.Name;
        }

        var isSimilarPasswords = request.NewPassword == request.CurrentPassword;
        var isPasswordUpdating = !string.IsNullOrWhiteSpace(request.NewPassword) && !isSimilarPasswords;
        if (isPasswordUpdating)
        {
            var invalidPassword = !_hasher.Verify(request.CurrentPassword, user.Password);
            if (invalidPassword)
            {
                return UpdateHandlerResult.Failed(UsersErrorCodes.INVALID_PASSWORD);
            }

            var nameStepResult = await ValidatePasswordStepAsync(request);
            if (!nameStepResult.Processed)
            {
                return UpdateHandlerResult.Failed(nameStepResult.Error);
            }
            user.Password = _hasher.Crypt(request.NewPassword);
        }

        // TODO: refactor
        var hasChanges = isNameUpdating || isPasswordUpdating;
        if (!hasChanges)
        {
            return UpdateHandlerResult.Failed(CommonErrorCodes.NOTHING_TO_UPDATE);
        }
        
        var affectedCount = await _domain.GetContextFor<User>().UpdateAsync(user);
        return UpdateHandlerResult.Success(affectedCount);
    }

    private async Task<StepHandlerResult> ValidateNameStepAsync(UpdateUserCommand request)
    {
        var invalidLength = request.Name.Length < 6 && request.Name.Length > 32;
        if (invalidLength)
        {
            return StepHandlerResult.Failed(UsersErrorCodes.INVALID_NAME_LENGTH);
        }

        var isTaken = await _domain.GetContextFor<User>().AnyAsync(u => u.Name == request.Name);
        if (isTaken)
        {
            // TODO: idk maybe create NAME_TAKEN const 
            return StepHandlerResult.Failed(UsersErrorCodes.ALREADY_EXISTS);
        }
        
        return StepHandlerResult.Success();
    }
    
    private async Task<StepHandlerResult> ValidatePasswordStepAsync(UpdateUserCommand request)
    {
        var invalidLength = request.NewPassword.Length < 6 && request.NewPassword.Length > 32;
        if (invalidLength)
        {
            return StepHandlerResult.Failed(UsersErrorCodes.INVALID_PASSWORD_LENGTH);
        }

        var isUnsecure = !Regex.IsMatch(request.NewPassword, RegexPatterns.SECURED_PASSWORD);
        if (isUnsecure)
        {
            return StepHandlerResult.Failed(UsersErrorCodes.PASSWORD_UNSECURE);
        }
        
        return StepHandlerResult.Success();
    }
}