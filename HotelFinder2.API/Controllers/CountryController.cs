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
    public class CountryController : Controller
    {


        private ICountryService countryService;
        private readonly IValidator<CountryModel> _countryValidator;
        public CountryController(ICountryService _countryService, IValidator<CountryModel> countryValidator)
        {
            countryService = _countryService;
            _countryValidator = countryValidator;
        }




        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var countries = countryService.GetAll();
            return Ok(countries);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var country = countryService.GetById(id);
            if(country != null)
            {
                return Ok(country);

            }
            return NotFound();
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CountryModel country)
        {
            var result = await _countryValidator.ValidateAsync(country);

            if(!result.IsValid)
            {
                return NotFound(result.Errors.Select(k => k.ErrorMessage));
            }
            var createdCountry = countryService.Create(country);
            return CreatedAtAction("Get", new { id = createdCountry.Id }, createdCountry);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CountryUpdateModel country)
        {
            if(countryService.GetById(country.Id) != null)
            {
                return Ok(countryService.Update(country));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(countryService.GetById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
