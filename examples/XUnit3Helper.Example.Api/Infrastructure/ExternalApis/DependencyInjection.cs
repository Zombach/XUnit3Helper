using Microsoft.Extensions.Options;
using Refit;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis.JsonPlaceHolder;
using XUnit3Helper.Example.Api.Infrastructure.ExternalApis.QuickPickDeal;

namespace XUnit3Helper.Example.Api.Infrastructure.ExternalApis;

internal static class DependencyInjection
{
    public static IServiceCollection AddExternalApis(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddOptionsWithValidateOnStart<JsonPlaceHolderOptions>()
            .Bind(configuration.GetSection(JsonPlaceHolderOptions.SectionKey));

        service.AddRefitClient<IJsonPlaceHolderClient>()
            .ConfigureHttpClient((provider, client) =>
            {
                var options = provider.GetRequiredService<IOptions<JsonPlaceHolderOptions>>();

                client.BaseAddress = new Uri(options.Value.BaseUrl);
            });

        service.AddOptionsWithValidateOnStart<QuickPickDealOptions>()
            .Bind(configuration.GetSection(QuickPickDealOptions.SectionKey));

        service.AddRefitClient<IQuickPickDealClient>()
            .ConfigureHttpClient((provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<QuickPickDealOptions>>();

            client.BaseAddress = new Uri(options.Value.BaseUrl);
        }); ;

        return service;
    }
}
