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
    public class ReservationOptionService : Service<ReservationOptionCreateDto, ReservationOptionUpdateDto, ReservationOptionListDto, ReservationOption>, IReservationOptionService
    {
        public ReservationOptionService(IMapper mapper, IValidator<ReservationOptionCreateDto> createDtoValidator, IValidator<ReservationOptionUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    
    }
}
