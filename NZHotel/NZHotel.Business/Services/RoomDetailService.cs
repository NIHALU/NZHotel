using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NZHotel.Business.Interfaces;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class RoomDetailService : Service<RoomDetailCreateDto, RoomDetailUpdateDto, RoomDetailListDto, RoomDetail>, IRoomDetailService

    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public RoomDetailService(IMapper mapper, IValidator<RoomDetailCreateDto> createDtoValidator, IValidator<RoomDetailUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<RoomDetailListDto>> Getlist()
        {
            var query = _uow.GetRepository<RoomDetail>().GetQuery();
            var list = await query.Include(x => x.Room).ToListAsync();
            return _mapper.Map<List<RoomDetailListDto>>(list);
        }


        public async Task<List<RoomDetailListDto>> GetDetail(int roomId)
        {
            //var query =await _uow.GetRepository<RoomDetail>().GetByFilterFirstAsync(x=>x.RoomId == roomId);
            //return  _mapper.Map<RoomDetailListDto>(query);

            var query = _uow.GetRepository<RoomDetail>().GetQuery();
            var list = await query.Include(x => x.Room).Where(x => x.RoomId == roomId).ToListAsync();
            return _mapper.Map<List<RoomDetailListDto>>(list);

        }
    }
}
