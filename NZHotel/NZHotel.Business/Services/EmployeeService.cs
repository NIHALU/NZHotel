using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NZHotel.Business.Interfaces;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities.Employees;

namespace NZHotel.Business.Services
{
    public class EmployeeService : Service<EmployeeCreateDto, EmployeeUpdateDto, EmployeeListDto, Employee>,IEmployeeService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public EmployeeService(IMapper mapper, IValidator<EmployeeCreateDto> createDtoValidator, IValidator<EmployeeUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow=uow;
            _mapper=mapper; 
         
        }


        public async Task<List<EmployeeListDto>> GetEmployeeList()
        {
            var query = _uow.GetRepository<Employee>().GetQuery();
            var list = await query.Include(x => x.Gender).Include(x => x.Department).ToListAsync();
            return _mapper.Map<List<EmployeeListDto>>(list);
        }


    }
}
