using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Business.Models
{
    public class ReservationModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public double RoomPrice { get; set; }
        public int Star { get; set; }

    }
    public class ReservationModelValidator : AbstractValidator<ReservationModel>
    {
        public ReservationModelValidator()
        {

            RuleFor(x => x.Name).Length(0, 20);

        }
    }
}
