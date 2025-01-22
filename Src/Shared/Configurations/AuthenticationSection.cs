using Microsoft.AspNetCore.Authentication;

namespace Stll.Shared.Configurations;

public class AuthenticationSection
{
    public string Key { get; init; } = GenerateRandomKey();
    public uint LifetimeHours { get; init; } = 10;

    private static string GenerateRandomKey()
    {
        var random = new Random();
        var bytes = new byte[32];
        
        random.NextBytes(bytes);
        
        return Base64UrlTextEncoder.Encode(bytes);
    }
}