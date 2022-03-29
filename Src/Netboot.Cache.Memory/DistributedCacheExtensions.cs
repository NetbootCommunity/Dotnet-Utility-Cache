using Microsoft.Extensions.DependencyInjection;
using Netboot.Cache.Domains;
using Netboot.Cache.Extensions;
using System;

namespace Netboot.Cache.Memory
{
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// Adds the memory cache with strongly typed read-through caching extensions.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <param name="options">The distributed cache options.</param>
        /// <returns></returns>
        public static IServiceCollection AddMemoryCache(this IServiceCollection services, Action<DistributedCacheOptions> options = null)
        {
            services.AddDistributedCache(options)
                .AddDistributedMemoryCache();
            return services;
        }
    }
}