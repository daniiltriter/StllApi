using Stll.CQRS.Abstractions;

namespace Requests.Users;

public class UserDto : IBusinessModel
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}