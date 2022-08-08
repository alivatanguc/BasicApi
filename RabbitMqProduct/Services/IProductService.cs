using RabbitMqProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqProduct.Services
{
    public interface IProductService
    {
      IEnumerable<Product> GetProductList();
        Product  GetProductId(int id);
       Product AddProduct(Product product);
       Product UpdateProduct(Product product);
        public bool DeleteProduct(int Id);

    }
}
