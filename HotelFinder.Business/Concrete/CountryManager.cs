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
        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Country Create(CountryModel countryModel)
        {
            Country country = new Country()
            {
               // City = hotelModel.City
                Name = countryModel.Name
            };
            return _countryRepository.Create(country);
        }

        
        public void Delete(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _countryRepository.GetById(id);
            if(entity != null)
            {
                _countryRepository.Delete(id);
            }
            else
            {
                return;
            }
        }

       

        public List<Country> GetAll()
        {
            return _countryRepository.GetAll();
        }

      

        public Country GetById(int id)
        {
            if(id > 0)
            {
                return _countryRepository.GetById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

       
        public Country Update(CountryUpdateModel countryUpdateModel)
        {

            var entity = _countryRepository.GetById(countryUpdateModel.Id);
            if(entity != null)
            {
                Country country = new Country()
                {
                    Id = countryUpdateModel.Id,
                    // City = hotelUpdateModel.City,
                    Name = countryUpdateModel.Name
                };
                return _countryRepository.Update(country);
            }
            else
            {
                return null;
            }
        }

      
    }
}
