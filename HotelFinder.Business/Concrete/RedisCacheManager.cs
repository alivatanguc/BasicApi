using HotelFinder.Business.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HotelFinder.Business.Concrete
{
  public   class RedisCacheManager: IRedisCacheService
    {


        private readonly IDistributedCache _cache;

        public RedisCacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {
            var value = _cache.GetString(key);

            if(value != null)
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }

        public T Set<T>(string key, T value)
        {
            var timeOut = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(24)
            };

            _cache.SetString(key, JsonSerializer.Serialize(value), timeOut);

            return value;
        }
    }
}
