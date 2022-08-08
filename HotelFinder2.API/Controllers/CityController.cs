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
    public class CityController : Controller
    {
        private ICityService cityService;


        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }






        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var cities = cityService.GetAllCities();
            return Ok(cities);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var city = cityService.GetCityById(id);
            if(city != null)
            {
                return Ok(city);

            }
            return NotFound();
        }


        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CityModel city)
        {
            var createdCity = cityService.CreateCityl(city);
            return CreatedAtAction("Get", new { id = createdCity.Id }, createdCity);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CityUpdateModel city)
        {
            if(cityService.GetCityById(city.Id) != null)
            {
                return Ok(cityService.UpdateCity(city));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(cityService.GetCityById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
