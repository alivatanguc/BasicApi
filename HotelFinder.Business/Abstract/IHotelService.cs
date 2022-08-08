using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {
        Hotel CreateHotel(HotelModel hotel);
        List<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        Hotel UpdateHotel(HotelUpdateModel hotel);
        void DeleteHotel(int id);
    }
}
