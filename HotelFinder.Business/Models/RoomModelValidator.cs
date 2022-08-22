using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
    public class RoomModelValidator : AbstractValidator<RoomModel>
    {
        public RoomModelValidator()
        {

            RuleFor(x => x.Capacitance).InclusiveBetween(0, 4);

        }
    }
}
