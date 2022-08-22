using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
    //public class CityModelValidator : AbstractValidator<CityModel>
    //{
    //    public CityModelValidator()
    //    {
            
    //        RuleFor(x => x.Name).Length(0, 20);

    //    }
    //}
}
