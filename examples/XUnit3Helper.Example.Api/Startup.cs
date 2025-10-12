using XUnit3Helper.Example.Api.Infrastructure.ExternalApis;
using XUnit3Helper.StartupModule;

namespace XUnit3Helper.Example.Api;

public sealed class Startup(IWebHostEnvironment environment)
    : IStartupModule
{
    public IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(environment.ContentRootPath)
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddCors();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(typeof(Startup).Assembly);
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
}
