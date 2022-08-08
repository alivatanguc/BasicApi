using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApicik.Repository
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IDistributedCache _redisCache;
        public RedisRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public Task<string> DeleteBasket(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<Hotel> GetBasket(string Name)
        {
            var hotel = await _redisCache.GetStringAsync(Name);
            if(String.IsNullOrEmpty(hotel))
                return null;
            return JsonConvert.DeserializeObject<Hotel>(hotel);
        }

        public async Task<Hotel> UpdateBasket(Hotel hotel)
        {

            await _redisCache.SetStringAsync(hotel.Name, JsonConvert.SerializeObject(hotel));

            return await GetBasket(hotel.Name);
        }
        
    }
}
