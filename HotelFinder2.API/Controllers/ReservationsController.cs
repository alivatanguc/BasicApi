using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using OtelFinder.Entities;


namespace HotelFinder2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {



        private IReservationService reservationService;
       
       

        public ReservationsController(IReservationService _reservationService)
        {
            reservationService = _reservationService;
           
        }




        [HttpGet]
        public IActionResult Get()
        {
            var reservations = reservationService.GetAll();
            return Ok(reservations);//200 döndürmemizi sağlar

        }
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var reservation = reservationService.GetByName(name);
            if(reservation != null)
            {
                return Ok(reservation);

            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]ReservationModel reservation)
        {
            var createdReservation = reservationService.Create(reservation);

            return CreatedAtAction("Get", new { name = createdReservation.Name }, createdReservation);//201 döndürür


        }

        [HttpPut]
        public IActionResult Put([FromBody]ReservationUpdateModel reservation)
        {
            if(reservationService.GetByName(reservation.Name) != null)
            {
                return Ok(reservationService.Update(reservation));
            }
            return NotFound();
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            if(reservationService.GetByName(name) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
