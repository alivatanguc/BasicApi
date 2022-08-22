using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete.GenericRepository;
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{

    public class HotelRepository : GenericRepository<Hotel> ,IHotelRepository
    {
       public HotelRepository(HotelDbContext hoteldbContext) : base(hoteldbContext)
        {

        }




        //public Hotel CreateHotel(Hotel hotel)
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {


        //        hoteldbContext.Hotels.Add(hotel);
        //        hoteldbContext.SaveChanges();
        //        return hotel;
        //    }
        //}

        //public Hotel GetHotelById(int id)
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        return hoteldbContext.Hotels.Include(k => k.City).FirstOrDefault(k => k.Id == id);
        //        //return hoteldbContext.Hotels.Include(k => k.Customers).FirstOrDefault(k => k.Id == id);

        //        return hoteldbContext.Hotels.Find(id);
        //    }
        //}

        //public List<Hotel> GetAllHotels()
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        return hoteldbContext.Hotels.Include(k => k.Customers).ToList();
        //        //return hoteldbContext.Hotels.Include(k => k.Category).ToList();
        //        // return hoteldbContext.Hotels.Include(k => k.City).ToList();
        //        //return hoteldbContext.Hotels.Include(k => k.Country).ToList();
        //        // return hoteldbContext.Hotels.Where(k => k.Star >=5 && k.RoomPrice>6900).ToList();
        //        //return hoteldbContext.Hotels.Skip(2).ToList();

        //        //hoteldbContext.Hotels.Join(hoteldbContext.Cities, k => k.Id);
        //        // where linq sorgusu ile koşullu bir ifade yazdık   
        //        //k yerine Hotel ismini de kullanabilirsin
        //        //skip linq içine attığımız değere kadar atlıyo

        //        //return (from p in hoteldbContext.Hotels where p.NumberOfRoom > 78 select p).ToList();

        //        //return (from a in hoteldbContext.Hotels where a.NumberOfRoom > 12 && a.Star > 6 select a).ToList();
        //        //return (from k in hoteldbContext.Hotels where k.RoomPrice > 6788 select k).ToList();

        //    }
        //    // throw new NotImplementedException();
        //}

        //public void DeleteHotel(int id)
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        var deletedHotel = GetHotelById(id);
        //        hoteldbContext.Hotels.Remove(deletedHotel);
        //        hoteldbContext.SaveChanges();
        //    }
        //}

        //public Hotel UpdateHotel(Hotel hotel)
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        hoteldbContext.Hotels.Update(hotel);
        //        hoteldbContext.SaveChanges();
        //        return hotel;
        //    }
        //}
    }
}
