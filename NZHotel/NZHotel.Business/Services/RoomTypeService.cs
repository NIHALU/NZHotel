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
    public class RoomTypeService: Service<RoomTypeCreateDto, RoomTypeUpdateDto, RoomTypeListDto, RoomType>, IRoomTypeService
    {
        public RoomTypeService(IMapper mapper, IValidator<RoomTypeCreateDto> createDtoValidator, IValidator<RoomTypeUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    }
}
