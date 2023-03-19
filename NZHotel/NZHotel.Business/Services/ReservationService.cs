using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using NZHotel.Business.Interfaces;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class ReservationService : Service<ReservationCreateDto, ReservationUpdateDto, ReservationListDto, Reservation>, IReservationService
    {
        private readonly IUow _uow;
  
        public ReservationService(IMapper mapper, IValidator<ReservationCreateDto> createDtoValidator, IValidator<ReservationUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
        }

        public async Task<ArrayList> GetBookedRoomList(BookRoomCreateDto dto)
        {
            ArrayList bookedRooms = new ArrayList();
            var reservationlist = await _uow.GetRepository<Reservation>().GetAllAsync(x =>x.Active==true);
            if (reservationlist.Count>0)
            {
                
                foreach (var reservation in reservationlist)
                {
                    var start = reservation.InStart(dto.StartingDate, dto.FinisingDate);
                    var finish = reservation.InFinish(dto.StartingDate, dto.FinisingDate);

                    if (start == true && finish == true)
                    {
                        bookedRooms.Add(reservation.RoomId);

                    }
                }
                return bookedRooms;
            }
            return bookedRooms;
        }

        
    }
}

