using AutoMapper;
using FluentValidation;
using NZHotel.Business.Interfaces;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Services
{
    public class GuestTypeService : Service<GuestTypeCreateDto, GuestTypeUpdateDto, GuestTypeListDto, GuestType>, IGuestTypeService
    {
        public GuestTypeService(IMapper mapper, IValidator<GuestTypeCreateDto> createDtoValidator, IValidator<GuestTypeUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
