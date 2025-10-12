using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using XUnit3Helper.Extensions;
using XUnit3Helper.Impl;

namespace XUnit3Helper.Tests.Extensions;

public sealed class MockExtensionsTests
{
    [Theory, CustomAutoData]
    public void AddMock_EmptyTypes(ServiceCollection services)
    {
        services.AddMocks();

        services.Count.Should().Be(0);
    }

    [Theory, CustomAutoData]
    public void AddMock(ServiceCollection services)
    {
        services.AddMocks(typeof(IClientProxy));

        using var serviceProvider = services.BuildServiceProvider();

        _ = serviceProvider.GetRequiredService<Mock<IClientProxy>>();
        _ = serviceProvider.GetRequiredService<IClientProxy>();

        services.Count.Should().Be(2);
    }

    [Theory, CustomAutoData]
    public void AddMocks2(ServiceCollection services)
    {
        services.AddHttpContextAccessor();
        using var serviceProvider = services.BuildServiceProvider();
        var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();

        services.AddMocks(typeof(IHttpContextAccessor));
        using var currentServiceProvider = services.BuildServiceProvider();
        var current = currentServiceProvider.GetRequiredService<IHttpContextAccessor>();
        var currentMock = currentServiceProvider.GetRequiredService<Mock<IHttpContextAccessor>>();

        current.Should().NotBe(httpContextAccessor);
        currentMock.Object.Should().Be(current);
    }
}
