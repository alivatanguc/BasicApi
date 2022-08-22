using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using Microsoft.AspNetCore.Mvc;
using OtelFinder.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelFinder2.API.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private ICityService cityService;

        private readonly IValidator<CityModel> _cityValidator;
        public CityController(ICityService _cityService, IValidator<CityModel> cityValidator)
        {
            cityService = _cityService;
            _cityValidator = cityValidator;
        }






        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var cities = cityService.GetAll();
            return Ok(cities);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var city = cityService.GetById(id);
            if(city != null)
            {
                return Ok(city);

            }
            return NotFound();
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CityModel city)
        {
            var result = await _cityValidator.ValidateAsync(city);

            if(!result.IsValid)
            {
                return NotFound(result.Errors.Select(k => k.ErrorMessage));
            }
            var createdCity = cityService.Create(city);
            return CreatedAtAction("Get", new { id = createdCity.Id }, createdCity);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CityUpdateModel city)
        {
            if(cityService.GetById(city.Id) != null)
            {
                return Ok(cityService.Update(city));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(cityService.GetById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
