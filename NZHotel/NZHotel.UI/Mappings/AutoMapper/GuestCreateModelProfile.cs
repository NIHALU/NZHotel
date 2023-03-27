using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class GuestCreateModelProfile:Profile
    {
        public GuestCreateModelProfile()
        {
            CreateMap<GuestCreateModel, GuestCreateDto>().ReverseMap();
        }
    }
}
