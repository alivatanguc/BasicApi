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
    public class CountryController : Controller
    {


        private ICountryService countryService;
        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }




        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var countries = countryService.GetAllCountries();
            return Ok(countries);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var country = countryService.GetCountryById(id);
            if(country != null)
            {
                return Ok(country);

            }
            return NotFound();
        }


        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CountryModel country)
        {
            var createdCountry = countryService.CreateCountry(country);
            return CreatedAtAction("Get", new { id = createdCountry.Id }, createdCountry);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CountryUpdateModel country)
        {
            if(countryService.GetCountryById(country.Id) != null)
            {
                return Ok(countryService.UpdateCountry(country));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(countryService.GetCountryById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
