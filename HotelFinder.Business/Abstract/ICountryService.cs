using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICountryService
    {
        Country CreateCountry(CountryModel country);
        List<Country> GetAllCountries();
        Country GetCountryById(int id);
        Country UpdateCountry(CountryUpdateModel country);
        void DeleteCountry(int id);
    }
}
