using Microsoft.Extensions.Caching.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;

namespace PostgreCache
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            var redisConnection = ConfigurationManager.ConnectionStrings["Redis"].ToString();
            var cache = new RedisCache(redisConnection);
            var transactionHandler = new CacheTransactionHandler(cache);
            AddInterceptor(transactionHandler);

            Loaded += (sender, args) =>
            {
                args.ReplaceService(
                    (s, _) => new CachingProviderServices(s, transactionHandler, new RedisCachingPolicy())
                    );
            };
        }
    }
}
