using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NZHotel.Business.Interfaces;
using NZHotel.Common;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class GuestReservationService : Service<GuestReservationCreateDto, GuestReservationUpdateDto, GuestReservationListDto, GuestReservation>, IGuestReservationService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GuestReservationService(IMapper mapper, IValidator<GuestReservationCreateDto> createDtoValidator, IValidator<GuestReservationUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<GuestReservationListDto>> CheckInOutList()
        {
            var query = _uow.GetRepository<GuestReservation>().GetQuery();
            var list = await query.Include(x => x.Guest).Include(x => x.Reservation).ThenInclude(x =>x.Room).ToListAsync();
            return _mapper.Map<List<GuestReservationListDto>>(list);

        }

        public async Task<List<GuestReservationListDto>> GetReservations(int guestId)
        {
            var query = _uow.GetRepository<GuestReservation>().GetQuery();
            var list = await query.Include(x => x.Guest).Include(x => x.Reservation).ThenInclude(x =>x.Room).Where(x => x.GuestId == guestId).ToListAsync();
            return _mapper.Map<List<GuestReservationListDto>>(list);
        }
    }
}
