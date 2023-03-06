using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NZHotel.Business.Interfaces;
using NZHotel.Common.Enums;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class RoomService : Service<RoomCreateDto, RoomUpdateDto, RoomListDto, Room>, IRoomService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public RoomService(IMapper mapper, IValidator<RoomCreateDto> createDtoValidator, IValidator<RoomUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<RoomListDto>> Getlist()
        {
            var query = _uow.GetRepository<Room>().GetQuery();
            var list = await query.Include(x => x.RoomStatus).Include(x => x.RoomType).ToListAsync();
            return _mapper.Map<List<RoomListDto>>(list);
        }

        public async Task<RoomListDto> GetFilteredRoom(int number)
        {
            var room = await _uow.GetRepository<Room>().GetByFilterFirstAsync(x => x.RoomTypeId == number);
            return _mapper.Map<RoomListDto>(room);
        }

        public async Task<List<RoomListDto>> GetNotBookedRoomList(params int[] list)
        {
            var allRooms = await _uow.GetRepository<Room>().GetAllAsync();

            for (int i = 0; i < list.Length; i++)
            {
                var room = await _uow.GetRepository<Room>().FindAsync(list[i]);
                allRooms.Remove(room);
            }
            return _mapper.Map<List<RoomListDto>>(allRooms);

        }
    }
}
