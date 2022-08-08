using HotelFinder.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class CountryRepository : ICountryRepository
    {
      

        Country ICountryRepository.CreateCountry(Country country)
        {
            using(var hoteldbContext = new HotelDbContext())
            {


                hoteldbContext.Countries.Add(country);
                 hoteldbContext.SaveChanges();
                return country;
            }
        }

      

      

        List<Country> ICountryRepository.GetAllCountries()
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                
                return hoteldbContext.Countries.Include(k => k.Hotels).ToList();
                //return hoteldbContext.Countries.ToList();
            }
        }

       public Country GetCountryById(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                return hoteldbContext.Countries.Include(k => k.Hotels).FirstOrDefault(k => k.Id == id);
                return hoteldbContext.Countries.Find(id);
            }
        }
        public void DeleteCountry(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                var deletedCountry = GetCountryById(id);
                hoteldbContext.Countries.Remove(deletedCountry);
                hoteldbContext.SaveChanges();
            }
        }

        Country ICountryRepository.UpdateCountry(Country country)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                hoteldbContext.Countries.Update(country);
                hoteldbContext.SaveChanges();
                return country;
            }
        }
    }
}
