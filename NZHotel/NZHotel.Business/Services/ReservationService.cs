using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NZHotel.Business.Extensions;
using NZHotel.Business.Interfaces;
using NZHotel.Common;
using NZHotel.Common.Enums;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.DTOs.BookRoomDtos;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class ReservationService : Service<ReservationCreateDto, ReservationUpdateDto, ReservationListDto, Reservation>, IReservationService
    {
        private readonly IUow _uow;
        private readonly IValidator<ReservationCreateDto> _reservationCreateDtoValidator;
        private readonly IValidator<ReservationUpdateDto> _reservationUpdateDtoValidator;

        private readonly IMapper _mapper;


        public ReservationService(IMapper mapper, IValidator<ReservationCreateDto> createDtoValidator, IValidator<ReservationUpdateDto> updateDtoValidator, IUow uow, IValidator<ReservationUpdateDto> reservationUpdateDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _reservationCreateDtoValidator = createDtoValidator;
            _reservationUpdateDtoValidator = reservationUpdateDtoValidator;
        }

        public async Task<ArrayList> GetBookedRoomList(BookRoomCreateDto dto)
        {
            ArrayList bookedRooms = new ArrayList();
            var reservationlist = await _uow.GetRepository<Reservation>().GetAllAsync(x => x.Active == true);
            if (reservationlist.Count > 0)
            {

                foreach (var reservation in reservationlist)
                {
                    var start = reservation.InStart(dto.StartingDate, dto.FinishingDate);
                    if (start == false)
                    {
                        bookedRooms.Add(reservation.RoomId);
                    }
                }
                return bookedRooms;
            }
            return bookedRooms;
        }

        public async Task<ArrayList> GetBookedRoomListForUpdate(BookRoomUpdateDto dto)
        {
            ArrayList bookedRooms = new ArrayList();
            var reservationlist = await _uow.GetRepository<Reservation>().GetAllAsync(x => x.Active == true && x.Id != dto.ReservationId);
            if (reservationlist.Count > 0)
            {

                foreach (var reservation in reservationlist)
                {
                    var start = reservation.InStart(dto.StartingDate, dto.FinishingDate);
                    if (start == false)
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
            var reservationlist = await _uow.GetRepository<Reservation>().GetAllAsync(x => x.Active == true);
            if (reservationlist.Count > 0)
            {

                foreach (var reservation in reservationlist)
                {
                    var start = reservation.InStart(dto.StartingDate, dto.FinishingDate);
                    if (start == false)
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

        public async Task<bool> CheckUpdateReservation(ReservationUpdateDto dto)
        {
            ArrayList bookedRooms = new ArrayList();
            var reservationlist = await _uow.GetRepository<Reservation>().GetAllAsync(x => x.Active == true && x.Id != dto.Id);

            if (reservationlist.Count > 0)
            {

                foreach (var reservation in reservationlist)
                {
                    var start = reservation.InStart(dto.StartingDate, dto.FinishingDate);
                    if (start == false)
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
                if (confirmed == true)
                {
                    var createdEntity = _mapper.Map<Reservation>(dto);
                    await _uow.GetRepository<Reservation>().CreateAsync(createdEntity);
                    await _uow.SaveChangesAsync();
                    return new Response<ReservationCreateDto>(ResponseType.Success, dto);
                }
                else
                {
                    return new Response<ReservationCreateDto>(ResponseType.NotFound, "Reservation has not been created!!");
                }
            }
            return new Response<ReservationCreateDto>(dto, result.ConvertToCustomValidationError());
        }




        public async Task<ReservationListDto> GetReservation(BookRoomCreateDto dto, int roomId)
        {
            var reservation = await _uow.GetRepository<Reservation>().GetByFilterFirstAsync(x => x.StartingDate == dto.StartingDate && x.FinishingDate == dto.FinishingDate && x.RoomId == roomId);
            return _mapper.Map<ReservationListDto>(reservation);
        }

        public async Task<IResponse<List<ReservationListDto>>> GetReservations(Expression<Func<Reservation, bool>> filter)
        {
            var query = _uow.GetRepository<Reservation>().GetQuery();
            var list = await query.Include(x => x.Customer).Include(x => x.ReservationOption).Include(x => x.ReservationType).Include(x=>x.PaymentType).Include(x => x.Room).Include(x => x.PaymentStatus).Where(filter).ToListAsync();
            var reservationList = _mapper.Map<List<ReservationListDto>>(list);
            return new Response<List<ReservationListDto>>(ResponseType.Success, reservationList);
        }


        public async Task<IResponse<ReservationUpdateDto>> UpdateReservation(ReservationUpdateDto dto)
        {
            var result = _reservationUpdateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var confirmed = await CheckUpdateReservation(dto);
                if (confirmed == true)
                {

                    var updatedEntity = await _uow.GetRepository<Reservation>().FindAsync(dto.Id);
                    if (updatedEntity == null)
                    {
                        return new Response<ReservationUpdateDto>(ResponseType.NotFound, $"Data which has {dto.Id} cannot be found!");
                    }
                    updatedEntity.UpdateDate = DateTime.Now;
                    _uow.GetRepository<Reservation>().Update(_mapper.Map<Reservation>(dto), updatedEntity);
                    await _uow.SaveChangesAsync();
                    return new Response<ReservationUpdateDto>(ResponseType.Success, dto);
                }
                else
                {
                    return new Response<ReservationUpdateDto>(ResponseType.NotFound, "Reservation has not been updated!!");
                }
            }
            return new Response<ReservationUpdateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<ReservationListDto>> GetReservation(string code)
        {
            var reservation = await _uow.GetRepository<Reservation>().GetByFilterAsync(x => x.ReservationCode == code);
            if (reservation == null)
            {
                return new Response<ReservationListDto>(ResponseType.NotFound, $"Data which has {code} cannot be found!");
            }
            var dto = _mapper.Map<ReservationListDto>(reservation);
            return new Response<ReservationListDto>(ResponseType.Success, dto);


        }


	}
}

