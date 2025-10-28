using XUnit3Helper.Example.Api;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Environment, builder.Configuration);

startup.ConfigureServices(builder.Services);

var applicationBuilder = builder.Build();
startup.Configure(applicationBuilder);

await applicationBuilder.RunAsync();
