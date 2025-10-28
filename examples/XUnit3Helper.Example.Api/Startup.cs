using XUnit3Helper.Example.Api.Application.Features.Common;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis;
using XUnit3Helper.StartupModule;

namespace XUnit3Helper.Example.Api;

public sealed class Startup(
    IWebHostEnvironment environment,
    ConfigurationManager configurationManager)
    : IStartupModule
{
    public IConfiguration Configuration { get; } = CreateConfiguration(environment, configurationManager);

    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddCors();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
            options.Assemblies = [typeof(BaseHandler<>)];
        });

        services.AddExternalApis(Configuration);

        return services;
    }

    public IApplicationBuilder Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseCors(policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseAuthorization();

        app.UseEndpoints(configure => configure.MapControllers());

        return app;
    }

    private static IConfiguration CreateConfiguration(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
    {
        return configurationManager
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
            .AddEnvironmentVariables()
            .Build();
    }
}
