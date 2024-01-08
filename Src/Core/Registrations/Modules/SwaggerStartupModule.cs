using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using Stll.Core.Registrations.Abstractions;

namespace Stll.Core.Registrations.Modules;

public class SwaggerStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        services.AddSwaggerDocument();
        services.AddSwaggerDocument(settings =>
        {
            settings.DocumentName = "OpenAPI 2";
            settings.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
            settings.AddSecurity("JWT Token", Enumerable.Empty<string>(),
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Copy this into the value field: Bearer {token}"
                }
            );
        });
    }
}