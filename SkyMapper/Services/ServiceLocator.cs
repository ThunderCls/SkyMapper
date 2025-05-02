using Microsoft.Extensions.DependencyInjection;

namespace SkyMapper.Services;

public static class ServiceLocator
{
    private static IServiceProvider _provider = null!;

    public static void Initialize(IServiceProvider provider)
    {
        _provider = provider;
    }

    public static T LocateService<T>()
    {
        return (T)_provider.CreateScope().ServiceProvider.GetRequiredService(typeof(T));
    }
}