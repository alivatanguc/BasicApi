using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
    public class HotelModel 
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        public int Star { get; set; }
        public int NumberOfRoom { get; set; }
        public double RoomPrice { get; set; }


    }

    //public class HotelModelValidator : AbstractValidator<HotelModel>
    //{
    //    public HotelModelValidator()
    //    {
    //        //RuleFor(x => x.Id).NotNull();
    //        RuleFor(x => x.Name).Length(0, 20);
    //        RuleFor(x => x.RoomPrice).NotNull();
    //        RuleFor(x => x.NumberOfRoom).InclusiveBetween(21, 60);
    //    }
    //}
}
