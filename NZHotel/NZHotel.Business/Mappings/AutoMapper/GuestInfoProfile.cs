using AutoMapper;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Mappings.AutoMapper
{
    public class GuestInfoProfile:Profile
    {
        public GuestInfoProfile()
        {
            CreateMap<GuestInfoCreateDto, GuestInfo>().ReverseMap();
            CreateMap<GuestInfoListDto, GuestInfo>().ReverseMap();
            CreateMap<GuestInfoUpdateDto, GuestInfo>().ReverseMap();
        }
    }
}
