using Microsoft.Extensions.DependencyInjection;
using Netboot.Utility.Cache.Domains;
using Netboot.Utility.Cache.Extensions;
using System;

namespace Netboot.Utility.Cache.Memory
{
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// Adds the memory cache with strongly typed read-through caching extensions.
        /// </summary>
        /// <param name="services">The services collection.</param>
        /// <param name="options">The distributed cache options.</param>
        /// <returns></returns>
        public static IServiceCollection AddTypedMemoryCache(this IServiceCollection services, Action<DistributedCacheOptions> options = null)
        {
            services.AddDistributedCache(options)
                .AddDistributedMemoryCache();
            return services;
        }
    }
}