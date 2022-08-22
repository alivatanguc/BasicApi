using FluentValidation;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.Extensions.Caching.Distributed;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IDistributedCache _redisCache;
        private readonly IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
       
        public Hotel Create(HotelModel hotelModel)
        {



            Hotel hotel = new Hotel()
            {
                CityId=hotelModel.CityId,
                CategoryId=hotelModel.CategoryId,
                CountryId=hotelModel.CountryId,
                Name = hotelModel.Name
                
            };
            return _hotelRepository.Create(hotel);
          
        }

        public void Delete(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _hotelRepository.GetById(id);
            if(entity != null)
            {
                 _hotelRepository.Delete(id);
            }
            else
            {
                return;
            }

        }
        

        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        public Hotel GetById(int id)
        {
            if(id > 0)
            {
                return _hotelRepository.GetById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

        public Hotel Update(HotelUpdateModel hotelUpdateModel)
        {
            var entity = _hotelRepository.GetById(hotelUpdateModel.Id);
            if(entity != null)
            {
                Hotel hotel = new Hotel()
                {
                    Id = hotelUpdateModel.Id,
                   //City = hotelUpdateModel.City,
                    Name = hotelUpdateModel.Name
                };
                return _hotelRepository.Update(hotel);
            }
            else
            {
                return null;
            }

        }
    }
}
