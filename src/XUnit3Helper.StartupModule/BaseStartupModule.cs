using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XUnit3Helper.StartupModule;

public abstract class BaseStartupModule(
    IWebHostEnvironment environment,
    ConfigurationManager configurationManager)
{
    public IConfiguration Configuration => field ??= ConfigureConfigurationInternal(environment, configurationManager);

    protected abstract IConfiguration ConfigureConfigurationInternal(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager);

    public abstract IServiceCollection ConfigureServices(IServiceCollection services);

    public abstract IApplicationBuilder Configure(IApplicationBuilder application);
}
