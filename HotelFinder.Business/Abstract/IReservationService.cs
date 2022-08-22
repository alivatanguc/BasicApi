

using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
   public interface IReservationService
    {
        Reservation Create(ReservationModel reservation);
        List<Reservation> GetAll();
        Reservation GetByName(string name);
        Reservation Update(ReservationUpdateModel reservation);
        void Delete(string name);
    }
}
