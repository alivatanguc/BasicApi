
using BasketApicik.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using OtelFinder.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQHotelConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";
            //var connection = factory.CreateConnection();
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost"); //RABBİTMQDAN ALDIĞIMIZ İSTEĞİ REDİSE YAZDIRMAK İÇİN KULLANIYORUZ
            //getting database instances of the redis  
            IDatabase database = conn.GetDatabase();
            //set value in redis server  
            

            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("Hotels", exclusive: false);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, eventArgs) =>
                    {
                        var body = eventArgs.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        //redis yazma kodu basitçe buraya yazılmalı.
                        database.StringSet(message,message);
                        //get value from redis server  
                        var value = database.StringGet("redisKey");
                        Console.WriteLine("Value cached in redis server is: " + value);
                       
                        Console.WriteLine($"Hotel message received: {message}");
                    };
                    channel.BasicConsume(queue: "hotels", autoAck: true, consumer: consumer);
                    Console.ReadKey();
                }
            }
        }
        public class RedisRepository : IRedisRepository
        {
            private readonly IDistributedCache _redisCache;
            public RedisRepository(IDistributedCache cache)
            {
                _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
            }

            public async Task<string> DeleteBasket(string Name)
            {
                _redisCache.Remove(Name);
                var response = Name;

                return response;
            }

            public async Task<Hotel> GetBasket(string Name)
            {
                var hotel = await _redisCache.GetStringAsync(Name);
                if(String.IsNullOrEmpty(hotel))
                    return null;
                return JsonConvert.DeserializeObject<Hotel>(hotel);
            }

            public async Task<Hotel> UpdateBasket(Reservation hotel)
            {

                await _redisCache.SetStringAsync(hotel.Name, JsonConvert.SerializeObject(hotel));

                return await GetBasket(hotel.Name);
            }


        }
    }
}

