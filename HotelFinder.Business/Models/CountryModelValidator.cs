using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
   
        public class CountryModelValidator : AbstractValidator<CountryModel>
        {
            public CountryModelValidator()
            {

                RuleFor(x => x.Name).Length(0, 20);
            //burda country kismında post işlemi yaparken isim girme olayında bir sınır belirliyoruz kullanıcıya 

            }
        }
    
}
