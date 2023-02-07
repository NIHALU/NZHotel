using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class RoomCreateViewModelProfile:Profile
    {
        public RoomCreateViewModelProfile()
        {
            CreateMap<RoomCreateViewModel, RoomCreateDto>().ReverseMap();
        }
    }
}
