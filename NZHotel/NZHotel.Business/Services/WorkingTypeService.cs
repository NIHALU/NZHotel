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
    public class WorkingTypeService : Service<WorkingTypeCreateDto, WorkingTypeUpdateDto, WorkingTypeListDto, WorkingType>, IWorkingTypeService
    {
        public WorkingTypeService(IMapper mapper, IValidator<WorkingTypeCreateDto> createDtoValidator, IValidator<WorkingTypeUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
