using System;
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
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;

        public ReservationService(IMapper mapper, IValidator<ReservationCreateDto> createDtoValidator, IValidator<ReservationUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
        }

        //public async Task<List<ReservationListDto>> Getlist(RoomBookCreateDto dto)
        //{
        //    Reservation reservation =new Reservation();
         

        //    var reservationlist=await _uow.GetRepository<Reservation>().GetAllAsync();
        //    foreach (var item in reservationlist )
        //    {
        //        var start = reservation.InStart(dto.StartingDate, dto.FinisingDate);
        //        var finish = reservation.InFinish(dto.StartingDate, dto.FinisingDate);

        //        if (start == true && finish == true)
        //        {
        //            var query = _uow.GetRepository<Reservation>().GetQuery();

        //            query.Where(x => x.StartingDate == dto.StartingDate && x.FinisingDate == dto.FinisingDate);
        //        }
        //        return 

        //    }

          

        }

    }

