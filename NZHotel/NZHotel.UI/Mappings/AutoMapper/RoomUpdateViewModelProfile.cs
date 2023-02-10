using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class RoomUpdateViewModelProfile:Profile
    {
        public RoomUpdateViewModelProfile()
        {
            CreateMap<RoomUpdateViewModel, RoomUpdateDto>().ReverseMap();
        }
    }
}
