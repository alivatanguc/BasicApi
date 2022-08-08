using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICityService
    {
        City CreateCityl(CityModel city);
        List<City> GetAllCities();
        City GetCityById(int id);
        City UpdateCity(CityUpdateModel city);
        void DeleteCity(int id);
    }
}
