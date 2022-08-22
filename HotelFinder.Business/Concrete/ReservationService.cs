
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess.Abstract;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class ReservationService : IReservationService
    {

        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }



        public Reservation Create(ReservationModel reservationModel)
        {
            Reservation reservation = new Reservation()
            {
                
                Name = reservationModel.Name
            };
            return _reservationRepository.Create(reservation);
        }

        public void Delete(string name)
        {

            var entity = _reservationRepository.GetByName(name);
            if(entity != null)
            {
                _reservationRepository.Delete(name);
            }
            else
            {
                return;
            }
        }



        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }



        public Reservation GetByName(string name)
        {

            if(name != null)
            {
                return _reservationRepository.GetByName(name);
            }

            throw new Exception("NAME CAN NOT BE NULL !!!");
        }


        public Reservation Update(ReservationUpdateModel reservationUpdateModel)
        {
            var entity = _reservationRepository.GetByName(reservationUpdateModel.Name);
            if(entity != null)
            {
                Reservation reservation = new Reservation()
                {
                    RoomId = reservationUpdateModel.RoomId,

                    Name = reservationUpdateModel.Name
                };
                return _reservationRepository.Update(reservation);
            }
            else
            {
                return null;
            }
        }



    }
}
