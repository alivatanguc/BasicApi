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
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public Room Create(RoomModel roomModel)
        {

            Room room = new Room()
            {
                //City = hotelModel.City
                Capacitance = roomModel.Capacitance
            };
            return _roomRepository.Create(room);
        }


        public void Delete(int id)
        {
            var entity = _roomRepository.GetById(id);
            if(entity != null)
            {
                _roomRepository.Delete(id);
            }
            else
            {
                return;
            }
        }

      
        public List<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }


        public Room GetById(int id)
        {
            if(id > 0)
            {
                return _roomRepository.GetById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

     
        

        public Room Update(RoomUpdateModel roomUpdateModel)
        {
            var entity = _roomRepository.GetById(roomUpdateModel.Id);
            if(entity != null)
            {
                Room room = new Room()
                {
                    Id = roomUpdateModel.Id,
                    //City = hotelUpdateModel.City,
                    Capacitance = roomUpdateModel.Capacitance
                };
                return _roomRepository.Update(room);
            }
            else
            {
                return null;
            }
        }

      
    }
}

