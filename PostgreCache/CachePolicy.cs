using EFCache;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreCache
{
    public class CachePolicy : CachingPolicy
    {
        protected override void GetExpirationTimeout(ReadOnlyCollection affectedEntitySets, out TimeSpan slidingExpiration, out DateTimeOffset absoluteExpiration)
        {
            slidingExpiration = TimeSpan.FromMinutes(5);
            absoluteExpiration = DateTimeOffset.Now.AddMinutes(30);
        }
    }
}
