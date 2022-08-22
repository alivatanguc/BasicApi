
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer Create(CustomerModel customerModel)
        {

            Customer customer = new Customer()
            {
                
                FirstName = customerModel.FirstName,
                LastName=customerModel.LastName
            };
            return _customerRepository.Create(customer);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            if(id > 0)
            {
                return _customerRepository.GetById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

        public Customer Update(CustomerUpdateModel customerUpdateModel)
        {
            var entity = _customerRepository.GetById(customerUpdateModel.CId);
            if(entity != null)
            {
                Customer customer = new Customer()
                {
                    CId = customerUpdateModel.CId,
                    FirstName = customerUpdateModel.FirstName,
                   // LastName = CustomerUpdateModel.LastName
                };
                return _customerRepository.Update(customer);
            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            var entity = _customerRepository.GetById(id);
            if(entity != null)
            {
                _customerRepository.Delete(id);
            }
            else
            {
                return;
            }
        }

       
    }
}






