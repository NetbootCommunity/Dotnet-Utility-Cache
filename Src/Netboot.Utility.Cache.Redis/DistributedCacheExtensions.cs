using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using Netboot.Utility.Cache.Domains;
using Netboot.Utility.Cache.Extensions;
using System;

namespace Netboot.Utility.Cache.Redis
{
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// Adds the redis cache with strongly typed read-through caching extensions.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <param name="options">The distributed cache options.</param>
        /// <returns></returns>
        public static IServiceCollection AddTypedRedisCache(this IServiceCollection services, Action<RedisCacheOptions> redisOptions, Action<DistributedCacheOptions> options = null)
        {
            services.AddDistributedCache(options)
                .AddStackExchangeRedisCache(redisOptions);
            return services;
        }
    }
}