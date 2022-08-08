using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryManager()
        {
            _countryRepository = new CountryRepository();
        }

        public Country CreateCountry(CountryModel countryModel)
        {
            Country country = new Country()
            {
               // City = hotelModel.City
                Name = countryModel.Name
            };
            return _countryRepository.CreateCountry(country);
        }

        
        public void DeleteCountry(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _countryRepository.GetCountryById(id);
            if(entity != null)
            {
                _countryRepository.DeleteCountry(id);
            }
            else
            {
                return;
            }
        }

       

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }

      

        public Country GetCountryById(int id)
        {
            if(id > 0)
            {
                return _countryRepository.GetCountryById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

       
        public Country UpdateCountry(CountryUpdateModel countryUpdateModel)
        {

            var entity = _countryRepository.GetCountryById(countryUpdateModel.Id);
            if(entity != null)
            {
                Country country = new Country()
                {
                    Id = countryUpdateModel.Id,
                    // City = hotelUpdateModel.City,
                    Name = countryUpdateModel.Name
                };
                return _countryRepository.UpdateCountry(country);
            }
            else
            {
                return null;
            }
        }

      
    }
}
