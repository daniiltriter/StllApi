using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Stll.Core.Configurations;

namespace Stll.Core.Helpers;

public class ConfigurationLoader
{
    public ConfigurationLoaderResponse LoadOrCreateJson(string path)
    {
        try
        {
            var hasCreated = File.Exists(path);
            if (!hasCreated)
            { 
                CreateJsonInternal(path);
            }

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(path);

            var configuration = configurationBuilder.Build();

            return ConfigurationLoaderResponse.Success(configuration);
        }
        catch (Exception exception)
        {
            return ConfigurationLoaderResponse.Failed(exception.Message);
        }
    }

    private static void CreateJsonInternal(string path)
    {
        using var stream = new FileStream(path, FileMode.OpenOrCreate);
        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var settingsTemplate = new ApplicationSettings();
        JsonSerializer.Serialize(stream, settingsTemplate, serializeOptions);
    }
}