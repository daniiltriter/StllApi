using AutoMapper;
using Stll.Commands.Users;

namespace Stll.WebAPI.Views.Users;

public class UserEndpointMapProfile : Profile
{
    public UserEndpointMapProfile()
    {
        CreateMap<RegisterUserEndpointRequest, RegisterUserCommand>();
    }
}