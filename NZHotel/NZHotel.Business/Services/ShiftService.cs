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
    public class ShiftService : Service<ShiftCreateDto, ShiftUpdateDto, ShiftListDto, Shift>, IShiftService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public ShiftService(IMapper mapper, IValidator<ShiftCreateDto> createDtoValidator, IValidator<ShiftUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<ShiftListDto>> Getlist()
        {
            var query = _uow.GetRepository<Shift>().GetQuery();
            var list = await query.Include(x => x.Employee).ToListAsync();
            return _mapper.Map<List<ShiftListDto>>(list);
        }
    }
}
