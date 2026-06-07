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
        using var enumerator = types.GetEnumerator();

        if (enumerator.MoveNext())
        {
            var methodeInfo = typeof(MockExtension).GetMethod(
                nameof(AddMock),
                BindingFlags.Static | BindingFlags.NonPublic,
                [typeof(IServiceCollection)]);

            ArgumentNullException.ThrowIfNull(methodeInfo);

            do
            {
                var genericMethodInfo = methodeInfo.MakeGenericMethod(enumerator.Current);
                services = (IServiceCollection)genericMethodInfo.Invoke(null, [services])!;
            } while (enumerator.MoveNext());
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
