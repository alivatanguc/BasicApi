using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICountryService
    {
        Country Create(CountryModel country);
        List<Country> GetAll();
        Country GetById(int id);
        Country Update(CountryUpdateModel country);
        void Delete(int id);
    }
}
