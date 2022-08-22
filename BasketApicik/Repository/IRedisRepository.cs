
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApicik.Repository
{
   public interface IRedisRepository
    {
        Task<Hotel> GetBasket(string Name);
        Task<Hotel> UpdateBasket(Reservation hotel);
        Task<string> DeleteBasket(string Name);
    }
}
