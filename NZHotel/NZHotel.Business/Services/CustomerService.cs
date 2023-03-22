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
    public class CustomerService : Service<CustomerCreateDto, CustomerUpdateDto, CustomerListDto, Customer>, ICustomerService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public CustomerService(IMapper mapper, IValidator<CustomerCreateDto> createDtoValidator, IValidator<CustomerUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Create(CustomerCreateDto dto)
        {
            var createdEntity = _mapper.Map<Customer>(dto);
            await _uow.GetRepository<Customer>().CreateAsync(createdEntity);
            await _uow.SaveChangesAsync();
        }

        public async Task<CustomerListDto> GetCustomer(string customerID)
        {
            var customer = await _uow.GetRepository<Customer>().GetByFilterFirstAsync(x => x.PassportNo == customerID || x.PassportNo==customerID );
            return _mapper.Map<CustomerListDto>(customer);
        }
    }
}
