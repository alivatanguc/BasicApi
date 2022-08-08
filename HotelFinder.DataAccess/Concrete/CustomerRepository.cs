using HotelFinder.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                return hoteldbContext.Customers.Include(k => k.Hotel).ToList();
                return hoteldbContext.Customers.ToList();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                return hoteldbContext.Customers.Find(id);
            }
        }

        public Customer CreateCustomer(Customer customer)
        {
            using(var hoteldbContext = new HotelDbContext())
            {


                hoteldbContext.Customers.Add(customer);

                hoteldbContext.SaveChanges();
                return customer;
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                hoteldbContext.Customers.Update(customer);
                hoteldbContext.SaveChanges();
                return customer;
            }
        }

        public void DeleteCustomer(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                var deletedCustomer = GetCustomerById(id);
                hoteldbContext.Customers.Remove(deletedCustomer);
                hoteldbContext.SaveChanges();
            }
        }
    }
}
//Linq filtreleme için yazılan kodların daha kısa yazılması için kullanılır 
