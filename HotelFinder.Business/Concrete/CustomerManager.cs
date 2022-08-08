
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
        public CustomerManager()
        {
            _customerRepository = new CustomerRepository();
        }
        public Customer CreateCustomer(CustomerModel customerModel)
        {

            Customer customer = new Customer()
            {
                
                FirstName = customerModel.FirstName,
                LastName=customerModel.LastName
            };
            return _customerRepository.CreateCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            if(id > 0)
            {
                return _customerRepository.GetCustomerById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

        public Customer UpdateCustomer(CustomerUpdateModel customerUpdateModel)
        {
            var entity = _customerRepository.GetCustomerById(customerUpdateModel.CId);
            if(entity != null)
            {
                Customer customer = new Customer()
                {
                    CId = customerUpdateModel.CId,
                    FirstName = customerUpdateModel.FirstName,
                   // LastName = CustomerUpdateModel.LastName
                };
                return _customerRepository.UpdateCustomer(customer);
            }
            else
            {
                return null;
            }
        }

        public void DeleteCustomer(int id)
        {
            var entity = _customerRepository.GetCustomerById(id);
            if(entity != null)
            {
                _customerRepository.DeleteCustomer(id);
            }
            else
            {
                return;
            }
        }

       
    }
}






