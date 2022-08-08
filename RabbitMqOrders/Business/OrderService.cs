using RabbitMqOrders.Model;
using RabbitMqOrders.Models;
using RabbitMqOrders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMqOrders.Business
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        public Order CreateOrder(OrderModel orderModel)
        {
            Order order = new Order()
            {

                OrderName = orderModel.OrderName,
                OrderPrice = orderModel.OrderPrice
            };
            return _orderRepository.CreateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            var entity = _orderRepository.GetOrderById(id);
            if(entity != null)
            {
                _orderRepository.DeleteOrder(id);
            }
            else
            {
                return;
            }
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            if(id > 0)
            {
                return _orderRepository.GetOrderById(id);
            }
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

        public Order UpdateOrder(OrderUpdateModel orderUpdateModel)
        {
            var entity = _orderRepository.GetOrderById(orderUpdateModel.Id);
            if(entity != null)
            {
                Order order = new Order()
                {
                    Id = orderUpdateModel.Id,
                    OrderName = orderUpdateModel.OrderName
                  
                };
                return _orderRepository.UpdateOrder(order);
            }
            else
            {
                return null;
            }
        }
    }
}
