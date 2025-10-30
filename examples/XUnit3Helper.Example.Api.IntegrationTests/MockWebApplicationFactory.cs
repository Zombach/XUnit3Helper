using System.Reflection;
using XUnit3Helper.Example.Api.Api.Controllers.Common;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;
using XUnit3Helper.Example.Api.IntegrationTests;
using XUnit3Helper.Integration;

[assembly: AssemblyFixture(typeof(MockWebApplicationFactory))]
namespace XUnit3Helper.Example.Api.IntegrationTests;

public sealed class MockWebApplicationFactory
    : BaseWebApplicationFactory<Startup>
{
    protected override Guid ServerKey { get; } = Guid.CreateVersion7();
    protected override Assembly ControllersAssembly { get; } = typeof(BaseController).Assembly;
    protected override IEnumerable<Type> ServiceTypeForMock => [typeof(IJsonPlaceHolderClient)];
}
