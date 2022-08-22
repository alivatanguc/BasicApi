using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete.GenericRepository;
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelDbContext hoteldbContext) : base(hoteldbContext)
        {

        }
        //public Room CreateRoom(Room room)
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {


        //        hoteldbContext.Rooms.Add(room);
        //        hoteldbContext.SaveChanges();
        //        return room;
        //    }
        //}




        //public void DeleteRoom(int id)
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        var deletedRoom = GetRoomById(id);
        //        hoteldbContext.Rooms.Remove(deletedRoom);
        //        hoteldbContext.SaveChanges();
        //    }
        //}


        //public List<Room> GetAllRooms()
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        return hoteldbContext.Rooms.Include(k => k.Hotels).ToList();
        //        return hoteldbContext.Rooms.ToList();
        //    }
        //}


        //public Room GetRoomById(int id)
        //{
        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        return hoteldbContext.Rooms.Include(k => k.Hotels).FirstOrDefault(k => k.Id == id);

        //        return hoteldbContext.Rooms.Find(id);
        //    }
        //}



        //public Room UpdateRoom(Room room)
        //{

        //    using(var hoteldbContext = new HotelDbContext())
        //    {
        //        hoteldbContext.Rooms.Update(room);
        //        hoteldbContext.SaveChanges();
        //        return room;

        //    }

        //}
    }
}
