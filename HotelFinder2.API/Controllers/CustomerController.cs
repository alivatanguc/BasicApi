using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;


        public CustomerController(ICustomerService _customerService ,IMapper mapper)
        {
            customerService = _customerService;
            _mapper = mapper;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            //var customer = new Customer();
            var Customer = customerService.GetAll();
            var customerinfo = _mapper.Map<List<CustomerInfoDto>>(Customer);
            //maplediğimiz şey liste halinde olduğu için list formunu kullanmak zorundayız ve maplediğimiz şeyi return yapmalıyız
            
          // return Ok(customers);//200 döndürmemizi sağlar
            return Ok(customerinfo);


        }
       
        // GET api/<controller>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var customer = customerService.GetById(id);
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




            var createdCustomer = customerService.Create(customer);
           
            return CreatedAtAction("Get", new { id = createdCustomer.CId }, createdCustomer);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CustomerUpdateModel customer)
        {
            if(customerService.GetById(customer.CId) != null)
            {
                return Ok(customerService.Update(customer));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(customerService.GetById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
