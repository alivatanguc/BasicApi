using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMqOrders.Business;
using RabbitMqOrders.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RabbitMqOrders.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

      
        [HttpGet]
        public IActionResult Get()
        {
            var orders = orderService.GetAllOrders();
            return Ok(orders);//200 döndürmemizi sağlar
        }
        [HttpGet("{id}")]
          public IActionResult Get(int id)
            {
                var order = orderService.GetOrderById(id);
                if(order != null)
                {
                    return Ok(order);

                }
                return NotFound();
            }
        [HttpPost]
        public IActionResult Post([FromBody]OrderModel order)
        {
            var createdOrder = orderService.CreateOrder(order);
            return CreatedAtAction("Get", new { id = createdOrder.Id }, createdOrder);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]OrderUpdateModel order)
        {
            if(orderService.GetOrderById(order.Id) != null)
            {
                return Ok(orderService.UpdateOrder(order));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(orderService.GetOrderById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
