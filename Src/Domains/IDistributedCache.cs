using Microsoft.Extensions.Caching.Distributed;
using System.Threading;
using System.Threading.Tasks;

namespace Netboot.Cache.Domains
{
    /// <summary>
    /// Represents a strongly-typed distributed cache
    /// </summary>
    public interface IDistributedCache<TKey, TValue>
    {
        /// <inheritdoc cref="IDistributedCache.Get"/>
        TValue Get(TKey key);

        /// <inheritdoc cref="IDistributedCache.GetAsync"/>
        Task<TValue> GetAsync(TKey key, CancellationToken token = default);

        /// <inheritdoc cref="IDistributedCache.Set"/>
        void Set(TKey key, TValue value, DistributedCacheEntryOptions options);

        /// <inheritdoc cref="IDistributedCache.SetAsync"/>
        Task SetAsync(TKey key, TValue value, DistributedCacheEntryOptions options, CancellationToken token = default);

        /// <inheritdoc cref="IDistributedCache.Refresh"/>
        void Refresh(TKey key);

        /// <inheritdoc cref="IDistributedCache.RefreshAsync"/>
        Task RefreshAsync(TKey key, CancellationToken token = default);

        /// <inheritdoc cref="IDistributedCache.Remove"/>
        void Remove(TKey key);

        /// <inheritdoc cref="IDistributedCache.RemoveAsync"/>
        Task RemoveAsync(TKey key, CancellationToken token = default);
    }

    /// <inheritdoc cref="IDistributedCache{TKey, TValue}"/>
    public interface IDistributedCache<TValue> : IDistributedCache<string, TValue>
    { }
}