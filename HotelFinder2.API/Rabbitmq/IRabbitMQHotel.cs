using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqProduct.RabitMQ
{
   public interface IRabbitMQHotel
    {
        public void SendHotelMessage<T>(T message);
    }
}
