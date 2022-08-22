using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface IRoomService
    {
        Room Create(RoomModel room);
        List<Room> GetAll();
        Room GetById(int id);
        Room Update(RoomUpdateModel room);
        void Delete(int id);

    }
}
