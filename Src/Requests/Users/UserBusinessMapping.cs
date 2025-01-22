using AutoMapper;
using Requests.Users;
using Stll.Types;

namespace Stll.Requests.Users;

public class UserBusinessMapping : Profile
{
    public UserBusinessMapping()
    {
        CreateMap<User, UserDto>();
    }
}