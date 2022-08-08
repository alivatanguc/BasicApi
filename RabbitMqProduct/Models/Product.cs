using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqProduct.Models
{
    public class Product
    { 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
       
        public int ProductRice { get; set; }
        public int ProductStock { get; set; }

    }
}
