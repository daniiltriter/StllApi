﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Stll.Domain.IoC;
using Stll.Infrastructure;
using Stll.Shared.Configurations;
using Stll.Types;
using Stll.WebAPI.Registrations.Abstractions;

namespace Stll.WebAPI.Registrations.Modules;

public class DomainStartupModule : IStartupModule
{
    private readonly IOptions<ApplicationSettings> _settings;

    public DomainStartupModule(IOptions<ApplicationSettings> settings)
    {
        _settings = settings;
    }
    public void Apply(IServiceCollection services)
    {

        var domainBuilder = services.AddDomainContext<ApplicationContext>(settings =>
        {
            settings.ConnectionString = _settings.Value.Domain.Connection;
        });

        domainBuilder.AddEntity<User>();
        domainBuilder.InMemory<User>();
    }
}