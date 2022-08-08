using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasketApicik.Repository;
using Microsoft.AspNetCore.Mvc;
using OtelFinder.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasketApicik.Controllers
{
    [Route("api/[controller]")]
    public class RedisController : Controller
    {
        private readonly IRedisRepository _repository;
        public RedisController(IRedisRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
       
        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(Hotel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Hotel>> GetBasket(string Name)
        {
            var hotel = await _repository.GetBasket(Name);
            return Ok();
        }

        // POST api/<controller>
       
        [HttpPost]
        [ProducesResponseType(typeof(Hotel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Hotel>> UpdateBasket([FromBody] Hotel hotel)
        {
            return Ok(await _repository.UpdateBasket(hotel));
        }
        // DELETE api/<controller>/5
        [HttpDelete("{HotelName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string Name)
        {
            await _repository.DeleteBasket(Name);
            return Ok();
        }
    }
}
