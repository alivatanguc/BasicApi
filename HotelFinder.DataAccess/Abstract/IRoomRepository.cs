using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();
        Room GetRoomById(int id);
        Room CreateRoom(Room room);
        Room UpdateRoom(Room room);
        void DeleteRoom(int id);
    }
}
