using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class ShiftUpdateModelProfile:Profile
    {
        public ShiftUpdateModelProfile()
        {
            CreateMap<ShiftUpdateModel, ShiftUpdateDto>().ReverseMap();
        }
    }
}
