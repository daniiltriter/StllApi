using AutoMapper;
using Stll.Core.Types;
using Stll.Core.Views.Users;

namespace Stll.Core.Commands.Users;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<RegisterUserEndpointRequest, RegisterUserCommand>();
        CreateMap<RegisterUserCommand, User>()
            .ForMember(_ => _.Role, _ => _.MapFrom(_ => UserRoles.Usual));
    }
}