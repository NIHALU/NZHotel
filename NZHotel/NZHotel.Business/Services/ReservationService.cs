using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using NZHotel.Business.Extensions;
using NZHotel.Business.Interfaces;
using NZHotel.Common;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class ReservationService : Service<ReservationCreateDto, ReservationUpdateDto, ReservationListDto, Reservation>, IReservationService
    {
        private readonly IUow _uow;
        private readonly IValidator<ReservationCreateDto> _reservationCreateDtoValidator;
        private readonly IMapper _mapper;


        public ReservationService(IMapper mapper, IValidator<ReservationCreateDto> createDtoValidator, IValidator<ReservationUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _reservationCreateDtoValidator = createDtoValidator;
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

        public async Task<bool> CheckReservation(ReservationCreateDto dto)
        {
            ArrayList bookedRooms = new ArrayList();
            var reservationlist = await  _uow.GetRepository<Reservation>().GetAllAsync(x => x.Active == true);
            if (reservationlist.Count > 0)
            {

                foreach (var reservation in reservationlist)
                {
                    var start = reservation.InStart(dto.StartingDate, dto.FinishingDate);
                    var finish = reservation.InFinish(dto.StartingDate, dto.FinishingDate);

                    if (start == true && finish == true)
                    {
                        bookedRooms.Add(reservation.RoomId);

                    }
  
                }
                if (bookedRooms.Contains(dto.RoomId))
                {
                    return false;
                }
                else
                {
                    return true;
                }
                 
                
            }
            return true;
        }

        public async Task<IResponse<ReservationCreateDto>> CreateReservation(ReservationCreateDto dto)
        {
            var result = _reservationCreateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var confirmed = await CheckReservation(dto);
                if (confirmed==true)
                {
                    var createdEntity = _mapper.Map<Reservation>(dto);
                    await _uow.GetRepository<Reservation>().CreateAsync(createdEntity);
                    await _uow.SaveChangesAsync();
                    return new Response<ReservationCreateDto>(ResponseType.Success, dto);
                }
                else
                {
                    return new Response<ReservationCreateDto>(ResponseType.NotFound,"Reservation has not been created!!");
                }
            }
            return new Response<ReservationCreateDto>(dto, result.ConvertToCustomValidationError());
        }


        public async Task<ReservationListDto> GetReservation(BookRoomCreateDto dto,int roomId)
        {
            var reservation = await _uow.GetRepository<Reservation>().GetByFilterFirstAsync(x => x.StartingDate==dto.StartingDate && x.FinishingDate==dto.FinisingDate && x.RoomId==roomId);
            return _mapper.Map<ReservationListDto>(reservation);
        }



    }
}

