using AutoMapper;
using FluentValidation;
using NZHotel.Business.Interfaces;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.Services
{
    public class CleaningStatusService : Service<CleaningStatusCreateDto, CleaningStatusUpdateDto, CleaningStatusListDto, CleaningStatus>, ICleaningStatusService
    {
        public CleaningStatusService(IMapper mapper, IValidator<CleaningStatusCreateDto> createDtoValidator, IValidator<CleaningStatusUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
