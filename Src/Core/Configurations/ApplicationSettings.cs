namespace Stll.Core.Configurations;

public class ApplicationSettings
{
    public string Url { get; set; } = "127.0.0.1:5000";
    public string DbConnection { get; set; } = @"Server=localhost;Database=stll_api;User=root;Password=password;";
}