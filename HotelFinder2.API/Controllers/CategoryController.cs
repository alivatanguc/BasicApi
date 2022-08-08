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
    public class CategoryController : Controller
    {
        private  ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = categoryService.GetAllCategories();
            return Ok(categories);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        
            public IActionResult Get(int id)
            {
                var category = categoryService.GetCategoryById(id);
                if(category != null)
                {
                    return Ok(category);

                }
                return NotFound();
            }
        

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CategoryModel category)
        {
            var createdCategory = categoryService.CreateCategory(category);
            return CreatedAtAction("Get", new { id = createdCategory.Id }, createdCategory);//201 döndürür

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]CategoryUpdateModel category)
        {
            if(categoryService.GetCategoryById(category.Id) != null)
            {
                return Ok(categoryService.UpdateCategory(category));
            }
            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(categoryService.GetCategoryById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
