using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands.IoC;
using Stll.CQRS.Results;
using Stll.Tests.CQRS.Models;
using Stll.Tests.CQRS.Requests;

namespace Stll.Tests.CQRS;

public class GetExecutorTests
{
    [Fact]
    public async Task Get_request_can_be_executed_as_custom()
    {
        var container = new ServiceCollection();
        container.AddBusinessExecutor(typeof(ExecuteCatcherTests).Assembly);
        var services = container.BuildServiceProvider();

        var catcher = services.GetService<IBusinessExecutor>();
        var request = new GetPingRequest();

        var catchResult = await catcher.ExecuteAsync<GetPingRequest, GetCatcherResult<PingModel>>(request);

        catchResult.Processed.Should().BeTrue();
        catchResult.Entities.Count.Should().Be(1);
        
        var entity = catchResult.Entities.First();
        entity.Content.Should().Be(nameof(PingModel));
    }
    
    [Fact]
    public async Task Get_request_can_be_executed()
    {
        var container = new ServiceCollection();
        container.AddBusinessExecutor(typeof(ExecuteCatcherTests).Assembly);
        var services = container.BuildServiceProvider();

        var catcher = services.GetService<IBusinessExecutor>();
        var request = new GetPingRequest();

        var catchResult = await catcher.GetSendAsync<GetPingRequest, PingModel>(request);

        catchResult.Processed.Should().BeTrue();
        catchResult.Entities.Count.Should().Be(1);
        
        var entity = catchResult.Entities.First();
        entity.Content.Should().Be(nameof(PingModel));
    }
}