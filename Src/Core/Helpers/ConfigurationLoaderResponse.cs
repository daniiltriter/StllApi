using Microsoft.Extensions.Configuration;

namespace Stll.Core.Helpers;

public class ConfigurationLoaderResponse
{
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public IConfiguration Value { get; set; }

    public static ConfigurationLoaderResponse Success(IConfiguration configuration) => new()
    {
        IsSuccess = true,
        ErrorMessage = null,
        Value = configuration,
    };

    public static ConfigurationLoaderResponse Failed(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessage = errorMessage,
        Value = null
    };
}