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
    public class CategoryController : Controller
    {
        private  ICategoryService categoryService;
        private readonly IValidator<CategoryModel> _categoryValidator;
        public CategoryController(ICategoryService _categoryService, IValidator<CategoryModel> categoryValidator)
        {
            categoryService = _categoryService;
            _categoryValidator = categoryValidator;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = categoryService.GetAll();
            return Ok(categories);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        
            public IActionResult Get(int id)
            {
                var category = categoryService.GetById(id);
                if(category != null)
                {
                    return Ok(category);

                }
                return NotFound();
            }
        

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryModel category)
        {
            var result = await _categoryValidator.ValidateAsync(category);

            if(!result.IsValid)
            {
                return NotFound(result.Errors.Select(k => k.ErrorMessage));
            }
            var createdCategory = categoryService.Create(category);
            return CreatedAtAction("Get", new { id = createdCategory.Id }, createdCategory);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CategoryUpdateModel category)
        {
            if(categoryService.GetById(category.Id) != null)
            {
                return Ok(categoryService.Update(category));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(categoryService.GetById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
