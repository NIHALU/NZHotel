using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using NZHotel.Business.Interfaces;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs.DepartmentDtos;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class DepartmentService : Service<DepartmentCreateDto, DepartmentUpdateDto, DepartmentListDto, Department>,IDepartmentService
    {
        public DepartmentService(IMapper mapper, IValidator<DepartmentCreateDto> createDtoValidator, IValidator<DepartmentUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
