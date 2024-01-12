using AutoMapper;
using Stll.CQRS.Commands.Users;

namespace Stll.WebAPI.Views.Users;

public class UserEndpointMapProfile : Profile
{
    public UserEndpointMapProfile()
    {
        CreateMap<RegisterUserEndpointRequest, RegisterUserCommand>();
    }
}