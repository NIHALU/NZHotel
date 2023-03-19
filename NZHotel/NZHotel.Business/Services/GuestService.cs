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
    public class GuestService : Service<GuestCreateDto, GuestUpdateDto, GuestListDto, Guest>, IGuestService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GuestService(IMapper mapper, IValidator<GuestCreateDto> createDtoValidator, IValidator<GuestUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(List<GuestCreateDto> dtos)
        {
            foreach (var item in dtos)
            {
                var createdEntity = _mapper.Map<Guest>(item);
                await _uow.GetRepository<Guest>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
            }
     
        }
    }
}
