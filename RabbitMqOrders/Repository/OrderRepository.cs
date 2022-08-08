using RabbitMqOrders.Data;
using RabbitMqOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqOrders.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order CreateOrder(Order order)
        {
            using(var orderdbContext = new DbContextClass())
            {


                orderdbContext.Orders.Add(order);

                orderdbContext.SaveChanges();
                return order;
            }
        }

        public void DeleteOrder(int id)
        {
            using(var orderdbContext = new DbContextClass())
            {
                var deletedOrder = GetOrderById(id);
                orderdbContext.Orders.Remove(deletedOrder);
                orderdbContext.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            using(var orderdbContext = new DbContextClass())
            {
               
                return orderdbContext.Orders.ToList();
            }
        }

        public Order GetOrderById(int id)
        {
            using(var orderdbContext = new DbContextClass())
            {
                return orderdbContext.Orders.Find(id);
            }
        }

        public Order UpdateOrder(Order order)
        {
            using(var orderdbContext = new DbContextClass())
            {
                orderdbContext.Orders.Update(order);
                orderdbContext.SaveChanges();
                return order;
            }
        }
    }
}
