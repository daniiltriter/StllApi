using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands.IoC;
using Stll.CQRS.Results;
using Stll.Tests.CQRS.Commands;

namespace Stll.Tests.CQRS;

public class ExecuteCatcherTests
{
    [Fact]
    public async Task Create_command_can_be_executed_as_custom()
    {
        var container = new ServiceCollection();
        container.AddCatcher(typeof(ExecuteCatcherTests).Assembly);
        var services = container.BuildServiceProvider();
        
        
        var catcher = services.GetService<IBusinessExecutor>();
        var command = new CreatePingCommand();

        var catchResult = await catcher.ExecuteAsync<CreatePingCommand, CreateCatcherResult>(command);
        
        catchResult.Processed.Should().BeTrue();
        catchResult.ErrorMessage.Should().BeNull();
        catchResult.CreatedId.Should().Be(1);
    }
    
    [Fact]
    public async Task Create_command_can_be_executed()
    {
        var container = new ServiceCollection();
        container.AddCatcher(typeof(ExecuteCatcherTests).Assembly);
        var services = container.BuildServiceProvider();

        var catcher = services.GetService<IBusinessExecutor>();
        var command = new CreatePingCommand();

        var catchResult = await catcher.CreateSendAsync(command);
        
        catchResult.Processed.Should().BeTrue();
        catchResult.ErrorMessage.Should().BeNull();
        catchResult.CreatedId.Should().Be(1);
    }

    [Fact]
    public async Task Create_command_cannot_be_executed_if_throw()
    {
        
    }
}