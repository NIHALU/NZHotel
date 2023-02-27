using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class RoomDetailCreateModelProfile:Profile
    {
        public RoomDetailCreateModelProfile()
        {
            CreateMap<RoomDetailCreateModel, RoomDetailCreateDto>().ReverseMap();
        }
    }
}
