using RabbitMqOrders.Model;
using RabbitMqOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqOrders.Business
{
    public interface IOrderService
    {
        Order CreateOrder(OrderModel order);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order UpdateOrder(OrderUpdateModel order);
        void DeleteOrder(int id);
    }
}
