namespace Stll.WebAPI.Views.Users;

public class UpdateUserEndpointRequest
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}