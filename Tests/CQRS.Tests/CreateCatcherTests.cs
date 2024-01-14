using Commands.Tests.Commands;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Stll.WebAPI.Commands;
using Stll.WebAPI.Commands.IoC;

namespace Commands.Tests;

public class CreateCatcherTests
{
    [Fact]
    public async Task Catcher_can_execute_ping_command()
    {
        var container = new ServiceCollection();
        container.AddCatcher(settings =>
        {
            settings.RegisterAssembly(typeof(CreateCatcherTests).Assembly);
        });

        var services = container.BuildServiceProvider();
        var catcher = services.GetService<ICatcher>();
        var command = new CreatePingCommand();

        var catchResult = await catcher.SafeExecuteAsync(command);

        catchResult.Processed.Should().BeTrue();
        catchResult.ErrorMessage.Should().BeNull();
        catchResult.CreatedId.Should().Be(1);
    }
}