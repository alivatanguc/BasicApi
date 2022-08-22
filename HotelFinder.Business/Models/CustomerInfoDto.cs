using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
   public  class CustomerInfoDto
    {
        public string Name { get; set; }
        public string CId { get; set; }

    }
    public enum CustomerCIdEnum
    {
        FirstCustomer = 1,

        SecondCustomer = 2,

        ThirdCustomer = 3

    }
}
