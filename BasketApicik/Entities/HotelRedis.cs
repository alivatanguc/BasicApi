
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApicik.Entities
{
    public class HotelRedis
    {
        public string Name { get; set; }
        public List<Reservation> Items { get; set; } = new List<Reservation>();
        public HotelRedis()
        {
        }
        public HotelRedis(string name)
        {
            Name = name;
        }

        public double TotalPrice
        {
            get
            {
                double totalprice = 0;
                foreach(var item in Items)
                {
                    totalprice += item.RoomPrice * item.Star;
                }
                return totalprice;
            }
        }
    }
}
