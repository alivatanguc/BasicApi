﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqProduct.RabitMQ
{
    public interface IOrderRabbitMQ
    {
        public void SendProductMessage<T>(T message);
    }
}
