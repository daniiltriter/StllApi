namespace Stll.Shared.Configurations;

public class ApplicationSettings
{
    public HostingSection Hosting { get; set; } = new();
    public DomainSection Domain { get; set; } = new();
    public AuthenticationSection Authentication { get; set; } = new();
}