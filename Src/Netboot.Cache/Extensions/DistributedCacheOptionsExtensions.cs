using Netboot.Cache.Domains;
using System;

namespace Netboot.Cache.Extensions
{
    public static class DistributedCacheOptionsExtensions
    {
        public static DistributedCacheOptions UseSerialization(
            this DistributedCacheOptions options,
            Func<object, byte[]> serializer,
            Func<byte[], Type, object> deserializer)
        {
            options.Serializer = serializer;
            options.Deserializer = deserializer;

            return options;
        }
    }
}