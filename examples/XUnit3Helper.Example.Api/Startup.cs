using XUnit3Helper.Example.Api.Infrastructure.ExternalApis;
using XUnit3Helper.StartupModule;

namespace XUnit3Helper.Example.Api;

public sealed class Startup(IWebHostEnvironment environment)
    : IStartupModule
{
    private string MediatRLicenseKey =
        "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzkwMzgwODAwIiwiaWF0IjoiMTc1ODkxMzk5NiIsImFjY291bnRfaWQiOiIwMTk5ODc3MGFkYzc3MWU3ODAyYmEyNmJhNmI2ZDk3OCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazYzcTNhNGJ0YzV3djViZDJuMmFqbms3Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.wKFtUCwYoI5XxCPV_b5MqRSkrwK6rWIh2_aan4fMxAfCF2w0DLjJiHtrTTxxGzqZwOl2Dr4pWbk7_6n4u4nOPx0rd7W_aGP4wirko7C4iFaOidakn1ZxeKoFEdlc66-wFek4ZiFETMB3oAaay2cLI24wWIUpD-1OtYHzRTLjNZ8-jcHmQbvnZUGJ3ZNv1KcRcXOLjL4jjV4q8AXUk2g9-TRxFWzc1WVADwDPfxygrn7U3CQf_doH2i45c7L8ItYeAAEnTFtCys4_gfPkhc9bIEzCYri8hvGgduUMcXAJPPJ-K9MYHu9WqjhvcKF45blK9flIw8eoDheYav_3TX2zAQ";

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

        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(typeof(Startup).Assembly);
            configure.LicenseKey = MediatRLicenseKey;
        });

        services.AddExternalApis(Configuration);
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
