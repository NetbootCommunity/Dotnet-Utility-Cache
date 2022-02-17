using MicroAutomation.Cache.Domains;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroAutomation.Cache.Extensions;

public static class DistributedCacheExtensions
{
    public static IServiceCollection AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
    {
        // Get cache configurations.
        var cacheConfig = configuration.GetConnectionString("DistributedCache");

        // Apply cache configurations.
        if (!string.IsNullOrEmpty(cacheConfig))
        {
            services.AddDistributedCache()
                .AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = cacheConfig;
                });
        }
        else
        {
            services.AddDistributedCache()
                .AddDistributedMemoryCache();
        }
        return services;
    }

    public static IServiceCollection AddDistributedCache(this IServiceCollection services, Action<DistributedCacheOptions> options = null)
    {
        services.Configure(options ?? (o => { }));
        services.TryAddScoped(typeof(IDistributedCache<>), typeof(DistributedCache<>));
        services.TryAddScoped(typeof(IDistributedCache<,>), typeof(DistributedCache<,>));

        return services;
    }

    public static void Set<TKey, TValue>(this IDistributedCache<TKey, TValue> cache, TKey key, TValue value)
    {
        cache.Set(key, value, new DistributedCacheEntryOptions());
    }

    public static Task SetAsync<TKey, TValue>(
        this IDistributedCache<TKey, TValue> cache,
        TKey key,
        TValue value,
        CancellationToken token = default)
    {
        return cache.SetAsync(key, value, new DistributedCacheEntryOptions(), token);
    }
}