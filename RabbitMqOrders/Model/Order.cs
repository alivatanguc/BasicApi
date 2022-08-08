using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqOrders.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public double OrderPrice { get; set; }
    }
}
