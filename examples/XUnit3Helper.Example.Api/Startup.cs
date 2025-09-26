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

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddCors();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
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
    }
}
