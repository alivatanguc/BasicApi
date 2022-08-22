using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
    public class HotelModelValidator : AbstractValidator<HotelModel>
    {
        public HotelModelValidator()
        {
           // RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(0, 20);
            RuleFor(x => x.RoomPrice).NotNull();
            RuleFor(x => x.NumberOfRoom).InclusiveBetween(21, 60);
            //hotelimizin swagger işlemleri sırasında koşul koyuyoruz mesela 3. kod da oda numara sayısı 21 ile 60 arasında bir değer girilebilir ancak 
        }
    }
}
