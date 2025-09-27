using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using XUnit3Helper.StartupModule;

namespace XUnit3Helper.Integration;

public abstract class BaseControllerTests<TServiceStartup, TApplicationFactory>(TApplicationFactory applicationFactory)
    where TApplicationFactory : BaseWebApplicationFactory<TServiceStartup>
    where TServiceStartup : class, IStartupModule
{
    private readonly Lazy<IServiceProvider> _lazyServices = new(() => applicationFactory.LazyServer.Value.Services, LazyThreadSafetyMode.ExecutionAndPublication);

    protected IApplicationBuilder Server => applicationFactory.LazyServer.Value ?? throw new ArgumentNullException(nameof(Server));
    protected IServiceProvider Services => _lazyServices.Value ?? throw new ArgumentNullException(nameof(Services));

    protected HttpClient CreateClient()
    {
        var httpClientFactory = Services
            .GetRequiredService<IHttpClientFactory>();

        var httpClient = httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri($"http://localhost:{applicationFactory.ServerPort}");

        return httpClient;
    }
}
