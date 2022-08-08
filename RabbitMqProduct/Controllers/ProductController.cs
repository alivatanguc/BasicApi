using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMqProduct.Models;
using RabbitMqProduct.RabitMQ;
using RabbitMqProduct.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RabbitMqProduct.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public ProductController(IProductService _productService,IRabbitMQProducer rabbitMQProducer)
        {
            productService = _productService;
            _rabbitMQProducer = rabbitMQProducer;
        }
           
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Product> ProductList()
        {
            var productList = productService.GetProductList();
            return productList;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Product GetProductId(int Id)
        {
            return productService.GetProductId(Id);
        }

        // POST api/<controller>
        [HttpPost]
        public Product AddProduct(Product product)
        {
            var productData = productService.AddProduct(product);
            _rabbitMQProducer.SendProductMessage(productData);
            return productData;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Product UpdateProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool DeleteProduct(int Id)
        {
            return productService.DeleteProduct(Id);
        }
    }
}
