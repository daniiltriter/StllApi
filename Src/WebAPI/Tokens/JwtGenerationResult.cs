﻿using Newtonsoft.Json;

namespace Stll.WebAPI.Tokens;

public class JwtGenerationResult
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    public static JwtGenerationResult New(string accessToken) => new()
    {
        AccessToken = accessToken
    };
}