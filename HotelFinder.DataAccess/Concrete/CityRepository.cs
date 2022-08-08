using HotelFinder.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class CityRepository : ICityRepository
    {
        public City CreateCity(City city)
        {
            using(var hoteldbContext = new HotelDbContext())
            {


                hoteldbContext.Cities.Add(city);
                hoteldbContext.SaveChanges();
                return city;
            }
        }




        public void DeleteCity(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                var deletedCity = GetCityById(id);
                hoteldbContext.Cities.Remove(deletedCity);
                hoteldbContext.SaveChanges();
            }
        }


        public List<City> GetAllCities()
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                return hoteldbContext.Cities.Include(k => k.Hotels).ToList();
                return hoteldbContext.Cities.ToList();
            }
        }


        public City GetCityById(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                return hoteldbContext.Cities.Include(k => k.Hotels).FirstOrDefault(k => k.Id == id);
               
                return hoteldbContext.Cities.Find(id);
            }
        }



        public City UpdateCity(City city)
        {

            using(var hoteldbContext = new HotelDbContext())
            {
                hoteldbContext.Cities.Update(city);
                hoteldbContext.SaveChanges();
                return city;

            }

        }


    }
}



