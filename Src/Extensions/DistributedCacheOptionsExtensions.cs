using MicroAutomation.Cache.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAutomation.Cache.Extensions;

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