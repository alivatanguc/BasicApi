using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface IRoomService
    {
        Room CreateRoom(RoomModel room);
        List<Room> GetAllRooms();
        Room GetRoomById(int id);
        Room UpdateRoom(RoomUpdateModel room);
        void DeleteRoom(int id);

    }
}
