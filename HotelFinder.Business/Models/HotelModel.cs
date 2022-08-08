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
}
