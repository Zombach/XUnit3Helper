using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XUnit3Helper.StartupModule;

public abstract class BaseStartupModule
{
    public IConfiguration Configuration { get; }

    protected BaseStartupModule(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
    {
        Configuration = ConfigureConfigurationInternal(environment, configurationManager);
    }

    protected abstract IConfiguration ConfigureConfigurationInternal(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager);

    public abstract IServiceCollection ConfigureServices(IServiceCollection services);

    public abstract IApplicationBuilder Configure(IApplicationBuilder app);
}
