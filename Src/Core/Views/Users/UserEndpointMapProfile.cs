using AutoMapper;
using Stll.Core.Commands.Users;

namespace Stll.Core.Views.Users;

public class UserEndpointMapProfile : Profile
{
    public UserEndpointMapProfile()
    {
        CreateMap<RegisterUserEndpointRequest, RegisterUserCommand>();
    }
}