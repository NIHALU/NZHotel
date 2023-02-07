﻿using System;
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
    public class RoomStatusService: Service<RoomStatusCreateDto, RoomStatusUpdateDto, RoomStatusListDto, RoomStatus>,IRoomStatusService
    {
        public RoomStatusService(IMapper mapper, IValidator<RoomStatusCreateDto> createDtoValidator, IValidator<RoomStatusUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    }
}
