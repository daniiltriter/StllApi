using AutoMapper;
using Stll.Types;
using Stll.Types.Variables;

namespace Stll.Commands.Users;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<RegisterUserCommand, User>()
            .ForMember(_ => _.Role, _ => _.MapFrom(_ => UserRoles.Usual));
    }
}