using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace XUnit3Helper.Extensions;

public static class MockExtension
{
    public static IServiceCollection AddMocks(
        this IServiceCollection services,
#if NET10_0
        params IEnumerable<Type> types)
#else
        params Type[] types)
#endif
    {
#if NET10_0
        using var enumerator = types.GetEnumerator();
#else
        var enumerator = types.GetEnumerator();
#endif
        if (enumerator.MoveNext())
        {
            var methodeInfo = typeof(MockExtension).GetMethod(
                nameof(AddMock),
                BindingFlags.Static | BindingFlags.NonPublic,
                [typeof(IServiceCollection)]);

            ArgumentNullException.ThrowIfNull(methodeInfo);

            do
            {
                var genericMethodInfo = methodeInfo.MakeGenericMethod(
#if !NET10_0
                    (Type)enumerator.Current);
#else
                    enumerator.Current);
#endif

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
