using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using OtelFinder.Entities;
using RabbitMqProduct.RabitMQ;

namespace HotelFinder2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
       
        
           
        private IHotelService hotelService;
        // public HotelsController(IHotelService _hotelService)
        // {
        //_hotelService = new HotelManager();
        //}
        private readonly IRabbitMQHotel _messagePublisher;


        public HotelsController(IHotelService _hotelService, IRabbitMQHotel messagePublisher)
        {
            hotelService = _hotelService;
            _messagePublisher = messagePublisher;
        }
        
           


        [HttpGet]
        public IActionResult Get()
        {
            var hotels = hotelService.GetAllHotels();
            return Ok(hotels);//200 döndürmemizi sağlar
            
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = hotelService.GetHotelById(id);
            if(hotel != null)
            {
                return Ok(hotel);
               
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]HotelModel hotel)
        {
            var createdHotel = hotelService.CreateHotel(hotel);
            _messagePublisher.SendHotelMessage(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel);//201 döndürür
          

        }

        [HttpPut]
        public IActionResult Put([FromBody]HotelUpdateModel hotel)
        {
            if(hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(hotelService.GetHotelById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
