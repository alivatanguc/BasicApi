using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface IRedisCacheService
    {
        T Get<T>(string key);
        T Set<T>(string key, T value);
    }
}
