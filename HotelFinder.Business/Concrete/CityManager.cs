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
        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }




        public City Create(CityModel cityModel)
        {
            City city = new City()
            {
                //City = cityModel.City,
            Name = cityModel.Name
            };
            return _cityRepository.Create(city);
        }

        public void Delete(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _cityRepository.GetById(id);
            if(entity != null)
            {
                _cityRepository.Delete(id);
            }
            else
            {
                return;
            }
        }

       

        public List<City> GetAll()
        {
            return _cityRepository.GetAll();
        }

      

        public City GetById(int id)
        {

            if(id > 0)
            {
                return _cityRepository.GetById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

     
        public City Update(CityUpdateModel cityUpdateModel)
        {
            var entity = _cityRepository.GetById(cityUpdateModel.Id);
            if(entity != null)
            {
                City city = new City()
                {
                    Id = cityUpdateModel.Id,
                    // City = hotelUpdateModel.City,
                    Name = cityUpdateModel.Name
                };
                return _cityRepository.Update(city);
            }
            else
            {
                return null;
            }
        }

       
    }
}
