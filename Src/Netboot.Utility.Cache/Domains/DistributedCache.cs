using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Netboot.Utility.Cache.Domains
{
    public class DistributedCache<TKey, TValue> : IDistributedCache<TKey, TValue>
    {
        private readonly IDistributedCache cache;
        private readonly DistributedCacheOptions cacheOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCache{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="cacheOptions">The cache options.</param>
        /// <exception cref="System.ArgumentException">No distributed cache specified. Check for Microsoft.Extensions.Caching.* packages</exception>
        public DistributedCache(IDistributedCache cache, IOptions<DistributedCacheOptions> cacheOptions)
        {
            this.cache = cache
                ?? throw new ArgumentException(
                    "No distributed cache specified. Check for Microsoft.Extensions.Caching.* packages");

            this.cacheOptions = cacheOptions.Value;
        }

        /// <summary>Gets a value with the given key.</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">key</exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Get(System.String)" />
        public TValue Get(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            var data = cache.Get(key.ToString());

            return data is null
                ? default
                : (TValue)cacheOptions.Deserializer(data, typeof(TValue));
        }

        /// <summary>Gets a value with the given key.</summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">key</exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.GetAsync(System.String,System.Threading.CancellationToken)" />
        public async Task<TValue> GetAsync(TKey key, CancellationToken token = default)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            var data = await cache.GetAsync(key.ToString(), token);

            return data is null
                ? default
                : (TValue)cacheOptions.Deserializer(data, typeof(TValue));
        }

        /// <summary>Sets a value with the given key.</summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Set(System.String,System.Byte[],Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions)" />
        public void Set(TKey key, TValue value, DistributedCacheEntryOptions options)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (value is null)
                throw new ArgumentNullException(nameof(value));

            var data = cacheOptions.Serializer(value);

            cache.Set(key.ToString(), data, options);
        }

        /// <summary>Sets a value with the given key.</summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.SetAsync(System.String,System.Byte[],Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions,System.Threading.CancellationToken)" />
        public Task SetAsync(
            TKey key,
            TValue value,
            DistributedCacheEntryOptions options,
            CancellationToken token = default)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (options is null)
                throw new ArgumentNullException(nameof(options));

            var data = cacheOptions.Serializer(value);

            return cache.SetAsync(key.ToString(), data, options, token);
        }

        /// <summary>Refreshes a value in the cache based on its key, resetting its sliding expiration timeout (if any).</summary>
        /// <param name="key"></param>
        /// <exception cref="System.ArgumentNullException">key</exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Refresh(System.String)" />
        public void Refresh(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            cache.Refresh(key.ToString());
        }

        /// <summary>Refreshes a value in the cache based on its key, resetting its sliding expiration timeout (if any).</summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">key</exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.RefreshAsync(System.String,System.Threading.CancellationToken)" />
        public Task RefreshAsync(TKey key, CancellationToken token = default)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            return cache.RefreshAsync(key.ToString(), token);
        }

        /// <summary>Removes the value with the given key.</summary>
        /// <param name="key"></param>
        /// <exception cref="System.ArgumentNullException">key</exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.Remove(System.String)" />
        public void Remove(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            cache.Remove(key.ToString());
        }

        /// <summary>Removes the value with the given key.</summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">key</exception>
        /// <inheritdoc cref="M:Microsoft.Extensions.Caching.Distributed.IDistributedCache.RemoveAsync(System.String,System.Threading.CancellationToken)" />
        public Task RemoveAsync(TKey key, CancellationToken token = default)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));

            return cache.RemoveAsync(key.ToString(), token);
        }
    }

    public sealed class DistributedCache<TValue> : DistributedCache<string, TValue>, IDistributedCache<TValue>
    {
        public DistributedCache(IDistributedCache cache, IOptions<DistributedCacheOptions> cacheOptions) : base(cache, cacheOptions)
        {
        }
    }
}