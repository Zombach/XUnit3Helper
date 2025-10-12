using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace XUnit3Helper.Extensions;

public static class MockExtension
{
    public static IServiceCollection AddMocks(
        this IServiceCollection services,
        params IEnumerable<Type> types)
    {
        var typesForMock = types.ToArray();
        if (typesForMock.Length is 0)
        {
            return services;
        }

        var methodeInfo = typeof(MockExtension)
            .GetMethod(
                nameof(AddMock),
                BindingFlags.Static | BindingFlags.NonPublic,
                [typeof(IServiceCollection)]);

        ArgumentNullException.ThrowIfNull(methodeInfo);

        foreach (var typeForMock in typesForMock)
        {
            var genericMethodInfo = methodeInfo.MakeGenericMethod(typeForMock);
            services = (IServiceCollection)genericMethodInfo.Invoke(null, [services])!;
        }

        return services;
    }

    private static IServiceCollection AddMock<TService>(IServiceCollection services)
        where TService : class
    {
        services.RemoveAll<TService>();

        var serviceMock = new Mock<TService>();
        services.AddScoped(_ => serviceMock);
        services.AddScoped(_ => serviceMock.Object);

        return services;
    }
}
