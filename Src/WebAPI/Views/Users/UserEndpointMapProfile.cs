using AutoMapper;
using Requests.Users;
using Stll.Commands.Users;

namespace Stll.WebAPI.Views.Users;

public class UserEndpointMapProfile : Profile
{
    public UserEndpointMapProfile()
    {
        CreateMap<RegisterUserEndpointRequest, RegisterUserCommand>();
        CreateMap<UpdateUserEndpointRequest, UpdateUserCommand>();
        CreateMap<UserDto, UserViewModel>();
    }
}