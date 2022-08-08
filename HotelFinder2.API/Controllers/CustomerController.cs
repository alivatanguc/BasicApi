using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using Microsoft.AspNetCore.Mvc;
using OtelFinder.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelFinder2.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var customers = customerService.GetAllCustomers();
            return Ok(customers);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var customer = customerService.GetCustomerById(id);
            if(customer != null)
            {
                return Ok(customer);

            }
            return NotFound();
        }


        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CustomerModel customer)
        {
            var createdCustomer = customerService.CreateCustomer(customer);
            return CreatedAtAction("Get", new { id = createdCustomer.CId }, createdCustomer);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CustomerUpdateModel customer)
        {
            if(customerService.GetCustomerById(customer.CId) != null)
            {
                return Ok(customerService.UpdateCustomer(customer));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(customerService.GetCustomerById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
