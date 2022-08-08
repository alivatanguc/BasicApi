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
    public class HotelManager : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelManager()
        {
            _hotelRepository = new HotelRepository();
        }
        public Hotel CreateHotel(HotelModel hotelModel)
        {
            Hotel hotel = new Hotel()
            {
                CityId=hotelModel.CityId,
                CategoryId=hotelModel.CategoryId,
                CountryId=hotelModel.CountryId,
                Name = hotelModel.Name
                
            };
            return _hotelRepository.CreateHotel(hotel);
          
        }

        public void DeleteHotel(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _hotelRepository.GetHotelById(id);
            if(entity != null)
            {
                 _hotelRepository.DeleteHotel(id);
            }
            else
            {
                return;
            }

        }
        

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            if(id > 0)
            {
                return _hotelRepository.GetHotelById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

        public Hotel UpdateHotel(HotelUpdateModel hotelUpdateModel)
        {
            var entity = _hotelRepository.GetHotelById(hotelUpdateModel.Id);
            if(entity != null)
            {
                Hotel hotel = new Hotel()
                {
                    Id = hotelUpdateModel.Id,
                   //City = hotelUpdateModel.City,
                    Name = hotelUpdateModel.Name
                };
                return _hotelRepository.UpdateHotel(hotel);
            }
            else
            {
                return null;
            }

        }
    }
}
