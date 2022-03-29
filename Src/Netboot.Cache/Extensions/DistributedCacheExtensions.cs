using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Netboot.Cache.Domains;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Netboot.Cache.Extensions

{
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// Adds the distributed cache.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static IServiceCollection AddDistributedCache(this IServiceCollection services, Action<DistributedCacheOptions> options = null)
        {
            services.Configure(options ?? (o => { }));
            services.TryAddScoped(typeof(IDistributedCache<>), typeof(DistributedCache<>));
            services.TryAddScoped(typeof(IDistributedCache<,>), typeof(DistributedCache<,>));

            return services;
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Set<TKey, TValue>(this IDistributedCache<TKey, TValue> cache, TKey key, TValue value)
        {
            cache.Set(key, value, new DistributedCacheEntryOptions());
        }

        /// <summary>
        /// Sets the specified key asynchronous.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public static Task SetAsync<TKey, TValue>(
            this IDistributedCache<TKey, TValue> cache,
            TKey key,
            TValue value,
            CancellationToken token = default)
        {
            return cache.SetAsync(key, value, new DistributedCacheEntryOptions(), token);
        }
    }
}