using AutoMapper;
using Requests.Users;
using Stll.CQRS.Abstractions;
using Stll.Domain.Abstractions;
using Stll.Types;
using Stll.WebAPI.Commands;

namespace Stll.Requests.Users;

public class FindUserHandler : IExecutorHandler<FindUserRequest, FindHandlerResult<UserDto>>
{
    private readonly IDomainService _domain;
    private readonly IMapper _mapper;
    
    public FindUserHandler(IDomainService domain, IMapper mapper)
    {
        _domain = domain;
        _mapper = mapper;
    }
    

    public async Task<FindHandlerResult<UserDto>> Handle(FindUserRequest request, CancellationToken cancellationToken)
    {
        // TODO: use Actor validation
        var users = await _domain.GetContextFor<User>().FindAsync(request.Id);
        var model = _mapper.Map<User, UserDto>(users);
        return FindHandlerResult<UserDto>.Success(model);
    }
}