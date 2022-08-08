using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICustomerService
    {
        Customer CreateCustomer(CustomerModel customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer UpdateCustomer(CustomerUpdateModel customer);
        void DeleteCustomer(int id);


    }
}
