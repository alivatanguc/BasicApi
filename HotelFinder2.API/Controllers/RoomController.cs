using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelFinder2.API.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {

        private IRoomService roomService;

        public RoomController(IRoomService _roomService)
        {
            roomService = _roomService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var rooms = roomService.GetAll();
            return Ok(rooms);//200 döndürmemizi sağlar
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room = roomService.GetById(id);
            if(room != null)
            {
                return Ok(room);

            }
            return NotFound();
        }

        // POST api/<controller>
        [HttpPost]

        public IActionResult Post([FromBody]RoomModel room)
        {
            var createdRoom = roomService.Create(room);
            return CreatedAtAction("Get", new { id = createdRoom.Id }, createdRoom);//201 döndürür

            return NotFound();
        }

    

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(roomService.GetById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
