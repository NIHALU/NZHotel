using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class RoomDetailUpdateModelProfile:Profile
    {
        public RoomDetailUpdateModelProfile()
        {
            CreateMap<RoomDetailUpdateModel, RoomDetailUpdateDto>().ReverseMap();
        }
    }

}
