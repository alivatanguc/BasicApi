using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {
        Hotel Create(HotelModel hotel);
        List<Hotel> GetAll();
        Hotel GetById(int id);
        Hotel Update(HotelUpdateModel hotel);
        void Delete(int id);
    }
}
