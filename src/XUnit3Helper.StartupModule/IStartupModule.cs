using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XUnit3Helper.StartupModule;

public interface IStartupModule
{
    IConfiguration Configuration { get; }

    IServiceCollection ConfigureServices(IServiceCollection services);

    IApplicationBuilder Configure(IApplicationBuilder app);
}
