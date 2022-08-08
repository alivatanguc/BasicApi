using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqOrders.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public double OrderPrice { get; set; }
    }
}
