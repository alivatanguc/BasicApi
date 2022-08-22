using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICustomerService
    {
        Customer Create(CustomerModel customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer Update(CustomerUpdateModel customer);
        void Delete(int id);


    }
}
