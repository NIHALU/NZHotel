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
using NZHotel.Entities.Employees;

namespace NZHotel.Business.Services
{
    public class EmployeeFileService : Service<EmployeeFileCreateDto, EmployeeFileUpdateDto, EmployeeFileListDto, EmployeeFile>, IEmployeeFileService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public EmployeeFileService(IMapper mapper, IValidator<EmployeeFileCreateDto> createDtoValidator, IValidator<EmployeeFileUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow=uow;
            _mapper=mapper; 
        }

        public async Task<List<EmployeeFileListDto>> Getlist()
        {
            var query = _uow.GetRepository<EmployeeFile>().GetQuery();
            var list = await query.Include(x => x.WorkingType).Include(x => x.Employee).ToListAsync();
            return _mapper.Map<List<EmployeeFileListDto>>(list);
        }

        public async Task<List<EmployeeFileListDto>> SeeFile(int employeeId)
        {
            var query = _uow.GetRepository<EmployeeFile>().GetQuery().Where(x => x.EmployeeId==employeeId);
            var list = await query.Include(x => x.WorkingType).Include(x => x.Employee).ToListAsync();
            return _mapper.Map<List<EmployeeFileListDto>>(list);

        }
    }
}
