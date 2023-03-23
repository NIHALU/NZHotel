using AutoMapper;
using FluentValidation;
using NZHotel.Business.Interfaces;
using NZHotel.DataAccess.UnitOfWork;
using NZHotel.DTOs;
using NZHotel.Entities;
using System.Threading.Tasks;

namespace NZHotel.Business.Services
{
    public class GuestInfoService : Service<GuestInfoCreateDto, GuestInfoUpdateDto, GuestInfoListDto, GuestInfo>, IGuestInfoService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GuestInfoService(IMapper mapper, IValidator<GuestInfoCreateDto> createDtoValidator, IValidator<GuestInfoUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow= uow;
        }

        public async Task Create(GuestInfoCreateDto dto)
        {
            var createdEntity = _mapper.Map<GuestInfo>(dto);
            await _uow.GetRepository<GuestInfo>().CreateAsync(createdEntity);
            await _uow.SaveChangesAsync();
        }
    }
}
