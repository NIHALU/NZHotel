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
    public class PaymentTypeService : Service<PaymentTypeCreateDto, PaymentTypeUpdateDto, PaymentTypeListDto, PaymentType>, IPaymentTypeService
    {
        public PaymentTypeService(IMapper mapper, IValidator<PaymentTypeCreateDto> createDtoValidator, IValidator<PaymentTypeUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
