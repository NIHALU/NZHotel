using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NZHotel.Business.Interfaces;
using NZHotel.Common;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZHotel.Business.Services
{
    public class GuestInfoService : Service<GuestInfoCreateDto, GuestInfoUpdateDto, GuestInfoListDto, GuestInfo>, IGuestInfoService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GuestInfoService(IMapper mapper, IValidator<GuestInfoCreateDto> createDtoValidator, IValidator<GuestInfoUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow= uow;
        }

        public async Task Create(GuestInfoCreateDto dto)
        {
            var createdEntity = _mapper.Map<GuestInfo>(dto);
            await _uow.GetRepository<GuestInfo>().CreateAsync(createdEntity);
            await _uow.SaveChangesAsync();
        }

        public async Task<IResponse<List<GuestInfoListDto>>> GuestInfo(int reservationId)
        {
            var query = _uow.GetRepository<GuestInfo>().GetQuery();
            var list = await query.Include(x => x.Reservation).Include(x => x.GuestType).Where(x => x.ReservationId == reservationId).ToListAsync();
            var guestInfoList = _mapper.Map<List<GuestInfoListDto>>(list);
            return new Response<List<GuestInfoListDto>>(ResponseType.Success, guestInfoList);
        }

        public async Task<IResponse<List<GuestInfoListDto>>> GuestInfoUpdated(int reservationId)
        {
            var query = _uow.GetRepository<GuestInfo>().GetQuery();
            var list = await query.Where(x=>x.ReservationId==reservationId).ToListAsync();
            var guestInfoList = _mapper.Map<List<GuestInfoListDto>>(list);
            return new Response<List<GuestInfoListDto>>(ResponseType.Success, guestInfoList);
        }
    }
}
