using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Netboot.Cache.Domains
{
    public class DistributedCacheOptions
    {
        public DistributedCacheOptions()
        {
            var options = new JsonSerializerOptions()
            {
                MaxDepth = 0,
                IgnoreReadOnlyProperties = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            Serializer = payload => JsonSerializer.SerializeToUtf8Bytes(payload, options);
            Deserializer = (bytes, type) => JsonSerializer.Deserialize(bytes, type, options);
        }

        internal Func<object, byte[]> Serializer { get; set; }
        internal Func<byte[], Type, object> Deserializer { get; set; }
    }
}