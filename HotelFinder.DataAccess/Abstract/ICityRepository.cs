using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess.Abstract
{
    public interface ICityRepository
    {
        List<City> GetAllCities();
        City GetCityById(int id);
        City CreateCity(City city);
        City UpdateCity(City city);
        void DeleteCity(int id);
    }
}
