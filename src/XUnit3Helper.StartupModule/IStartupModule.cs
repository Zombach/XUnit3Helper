using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XUnit3Helper.StartupModule;

public interface IStartupModule
{
    IConfiguration Configuration { get; }

    void ConfigureServices(IServiceCollection services);

    void Configure(IApplicationBuilder app);
}
