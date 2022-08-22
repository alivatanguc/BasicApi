using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
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
        private readonly IValidator<HotelModel> _hotelValidator;
        
        private readonly ISendMessageHotel _messagePublisher;


        public HotelsController(IHotelService _hotelService, ISendMessageHotel messagePublisher,IValidator<HotelModel> hotelValidator)
        {
            hotelService = _hotelService;
            _messagePublisher = messagePublisher;
            _hotelValidator = hotelValidator;
        }




        [HttpGet]
        public IActionResult Get()
        {
            var hotels = hotelService.GetAll();
            return Ok(hotels);//200 döndürmemizi sağlar

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = hotelService.GetById(id);
            if(hotel != null)
            {
                return Ok(hotel);

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HotelModel hotel)
        {
            var result = await _hotelValidator.ValidateAsync(hotel);

            if(!result.IsValid)
            {
                return NotFound(result.Errors.Select(k => k.ErrorMessage));
            }

            var createdHotel = hotelService.Create(hotel);
            _messagePublisher.SendHotelMessage(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel);//201 döndürür


        }

        [HttpPut]
        public IActionResult Put([FromBody]HotelUpdateModel hotel)
        {
            if(hotelService.GetById(hotel.Id) != null)
            {
                return Ok(hotelService.Update(hotel));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(hotelService.GetById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
