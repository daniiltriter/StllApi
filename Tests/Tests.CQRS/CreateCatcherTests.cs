using Commands.Tests.Commands;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Stll.Commands.Commands;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands.IoC;
using Stll.CQRS.Results;

namespace Commands.Tests;

public class CreateCatcherTests
{
    [Fact]
    public async Task Catcher_can_execute_ping_command()
    {
        var container = new ServiceCollection();
        container.AddCatcher(typeof(CreateCatcherTests).Assembly);
        var services = container.BuildServiceProvider();
        
        
        var catcher = services.GetService<ICatcher>();
        var command = new CreatePingCommand();

        var catchResult = await catcher.SafeExecuteAsync<CreatePingCommand, CreateCatcherResult>(command);
        
        catchResult.Processed.Should().BeTrue();
        catchResult.ErrorMessage.Should().BeNull();
        catchResult.CreatedId.Should().Be(1);
    }
}