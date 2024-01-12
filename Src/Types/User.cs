using Stll.Domain.Abstractions;

namespace Stll.Types;

public class User : IEntity
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}