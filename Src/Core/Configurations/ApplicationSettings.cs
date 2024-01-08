namespace Stll.Core.Configurations;

public class ApplicationSettings
{
    public HostingSection Hosting { get; set; } = new();
    public DomainSection Domain { get; set; } = new();
}