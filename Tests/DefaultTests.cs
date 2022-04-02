using FluentAssertions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Netboot.Utility.Cache.Domains;
using Netboot.Utility.Cache.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Netboot.Utility.Cache.Test
{
    public class DefaultTests
    {
        /// <summary>
        /// The instance if the distributed cache.
        /// </summary>
        private readonly DistributedCache<Guid> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultTests"/> class.
        /// </summary>
        public DefaultTests()
        {
            var memoryCache = new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));
            var cacheOption = Options.Create(new DistributedCacheOptions());
            _cache = new DistributedCache<Guid>(memoryCache, cacheOption);
        }

        [Fact]
        public void CanAddValue()
        {
            // Act
            Action act = () => _cache.Set(nameof(CanAddValue), Guid.NewGuid());

            // Xunit test
            act.Should().NotThrow();
        }

        [Fact]
        public void CanGetValue()
        {
            // Arrange
            var data = Guid.NewGuid();
            _cache.Set(nameof(CanGetValue), data);

            // Act
            var act = _cache.Get(nameof(CanGetValue));

            // Xunit test
            act.Should().As<Guid>();
            act.Should().NotBeEmpty();
            act.Should().Be(data);
        }

        [Fact]
        public async Task CanGetValueAsync()
        {
            // Arrange
            var data = Guid.NewGuid();
            await _cache.SetAsync(nameof(CanGetValueAsync), data);

            // Act
            var act = await _cache.GetAsync(nameof(CanGetValueAsync));

            // Xunit test
            act.Should().As<Guid>();
            act.Should().NotBeEmpty();
            act.Should().Be(data);
        }

        [Fact]
        public void CanRefreshValue()
        {
            // Arrange
            var data = Guid.NewGuid();
            _cache.Set(nameof(CanRefreshValue), data);

            // Act
            Action act = () => _cache.Refresh(nameof(CanRefreshValue));

            // Xunit test
            act.Should().NotThrow();
        }

        [Fact]
        public async Task CanRefreshValueAsync()
        {
            // Arrange
            var data = Guid.NewGuid();
            await _cache.SetAsync(nameof(CanRefreshValue), data);

            // Act
            Func<Task> act = () => _cache.RefreshAsync(nameof(CanRefreshValue));

            // Xunit test
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public void CanRemoveValue()
        {
            // Arrange
            var data = Guid.NewGuid();
            _cache.Set(nameof(CanRemoveValue), data);

            // Act
            _cache.Remove(nameof(CanRemoveValue));
            var act = _cache.Get(nameof(CanRemoveValue));

            // Xunit test
            act.Should().As<Guid>();
            act.Should().BeEmpty();
        }

        [Fact]
        public async Task CanRemoveValueAsync()
        {
            // Arrange
            var data = Guid.NewGuid();
            await _cache.SetAsync(nameof(CanAddValue), data);

            // Act
            await _cache.RemoveAsync(nameof(CanAddValue));
            var act = await _cache.GetAsync(nameof(CanAddValue));

            // Xunit test
            act.Should().As<Guid>();
            act.Should().BeEmpty();
        }
    }
}