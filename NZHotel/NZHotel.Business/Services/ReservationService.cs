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

        public async Task<ArrayList> GetBokeedRoomList(RoomBookCreateDto dto)
        {

            var reservationlist = await _uow.GetRepository<Reservation>().GetAllAsync();
            ArrayList liste = new ArrayList();
            foreach (var reservation in reservationlist)
            {
                var start = reservation.InStart(dto.StartingDate, dto.FinisingDate);
                var finish = reservation.InFinish(dto.StartingDate, dto.FinisingDate);

                if (start == true && finish == true)
                {
                    liste.Add(reservation.RoomId);

                }
            }
            return liste;

        }

        
    }
}

