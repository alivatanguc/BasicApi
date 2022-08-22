using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {

            RuleFor(x => x.FirstName).Length(0, 20);
            RuleFor(x => x.LastName).Length(0, 20);
            RuleFor(x => x.Phone).Length(10, 11);
            RuleFor(x => x.Age).InclusiveBetween(18, 99);

        }
    }
}
