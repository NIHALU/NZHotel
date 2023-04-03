using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class ShiftCreateModelProfile:Profile
    {
        public ShiftCreateModelProfile()
        {
            CreateMap<ShiftCreateModel, ShiftCreateDto>().ReverseMap();
        }
    }
}
