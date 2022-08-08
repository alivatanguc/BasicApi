using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomManager()
        {
            _roomRepository = new RoomRepository();
        }
       

        public Room CreateRoom(RoomModel roomModel)
        {

            Room room = new Room()
            {
                //City = hotelModel.City
                Capacitance = roomModel.Capacitance
            };
            return _roomRepository.CreateRoom(room);
        }


        public void DeleteRoom(int id)
        {
            var entity = _roomRepository.GetRoomById(id);
            if(entity != null)
            {
                _roomRepository.DeleteRoom(id);
            }
            else
            {
                return;
            }
        }

      
        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }


        public Room GetRoomById(int id)
        {
            if(id > 0)
            {
                return _roomRepository.GetRoomById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

     
        

        public Room UpdateRoom(RoomUpdateModel roomUpdateModel)
        {
            var entity = _roomRepository.GetRoomById(roomUpdateModel.Id);
            if(entity != null)
            {
                Room room = new Room()
                {
                    Id = roomUpdateModel.Id,
                    //City = hotelUpdateModel.City,
                    Capacitance = roomUpdateModel.Capacitance
                };
                return _roomRepository.UpdateRoom(room);
            }
            else
            {
                return null;
            }
        }

      
    }
}

