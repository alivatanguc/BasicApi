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
    public class CityManager : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityManager()
        {
            _cityRepository = new CityRepository();
        }
        

       

        public City CreateCityl(CityModel cityModel)
        {
            City city = new City()
            {
                //City = cityModel.City,
            Name = cityModel.Name
            };
            return _cityRepository.CreateCity(city);
        }

        public void DeleteCity(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _cityRepository.GetCityById(id);
            if(entity != null)
            {
                _cityRepository.DeleteCity(id);
            }
            else
            {
                return;
            }
        }

       

        public List<City> GetAllCities()
        {
            return _cityRepository.GetAllCities();
        }

      

        public City GetCityById(int id)
        {

            if(id > 0)
            {
                return _cityRepository.GetCityById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

     
        public City UpdateCity(CityUpdateModel cityUpdateModel)
        {
            var entity = _cityRepository.GetCityById(cityUpdateModel.Id);
            if(entity != null)
            {
                City city = new City()
                {
                    Id = cityUpdateModel.Id,
                    // City = hotelUpdateModel.City,
                    Name = cityUpdateModel.Name
                };
                return _cityRepository.UpdateCity(city);
            }
            else
            {
                return null;
            }
        }

       
    }
}
