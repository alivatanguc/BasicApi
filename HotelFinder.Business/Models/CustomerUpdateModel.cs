using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
   public class CustomerUpdateModel
    {
        public int CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HotelId { get; set; }

    }
}
