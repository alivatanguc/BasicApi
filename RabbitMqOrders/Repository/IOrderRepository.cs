using RabbitMqOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqOrders.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order CreateOrder(Order order);
        Order UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
