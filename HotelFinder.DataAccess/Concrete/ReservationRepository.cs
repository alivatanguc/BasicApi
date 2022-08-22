
using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete.GenericRepository;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(HotelDbContext hoteldbContext) : base(hoteldbContext)
        {

        }

        public Reservation GetByName(string name)
        {
            using(var reservationdbContext = new HotelDbContext())
            {


                return reservationdbContext.Reservations.Find(name);
            }
        }





        //public Reservation CreateReservation(Reservation reservation)
        //{


        //    using(var reservationdbContext = new HotelDbContext())
        //    {


        //        reservationdbContext.Reservations.Add(reservation);
        //        reservationdbContext.SaveChanges();
        //        return reservation;
        //    }
        //}

        //public Reservation GetReservationByName(string name)
        //{
        //    using(var reservationdbContext = new HotelDbContext())
        //    {


        //        return reservationdbContext.Reservations.Find(name);
        //    }
        //}

        //public List<Reservation> GetAllReservations()
        //{
        //    using(var reservationdbContext = new HotelDbContext())
        //    {
        //        return reservationdbContext.Reservations.ToList();

        //    }

        //}

        public void Delete(string name)
        {
            using(var reservationdbContext = new HotelDbContext())
            {
                var deletedReservation = GetByName(name);
                reservationdbContext.Reservations.Remove(deletedReservation);
                reservationdbContext.SaveChanges();
            }
        }
    }
}
    

    //public Reservation UpdateReservation(Reservation reservation)
    //{
    //    using(var reservationdbContext = new HotelDbContext())
    //    {
    //        reservationdbContext.Reservations.Update(reservation);
    //        reservationdbContext.SaveChanges();
    //        return reservation;
    //    }
    //}









