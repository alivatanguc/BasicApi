using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICityService
    {
        City Create(CityModel city);
        List<City> GetAll();
        City GetById(int id);
        City Update(CityUpdateModel city);
        void Delete(int id);
    }
}
