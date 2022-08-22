
using HotelFinder.DataAccess.Abstract;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        //List<Reservation> GetAllReservations();
        Reservation GetByName(string name);
        //Reservation CreateReservation(Reservation reservation);
        //Reservation UpdateReservation(Reservation reservation);
        void Delete(string name);
    }
}

