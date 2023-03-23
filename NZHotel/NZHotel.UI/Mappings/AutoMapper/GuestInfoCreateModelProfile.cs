using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class GuestInfoCreateModelProfile:Profile
    {
        public GuestInfoCreateModelProfile()
        {
            CreateMap<GuestInfoCreateModel, GuestInfoCreateDto>().ReverseMap();

        }
    }
}
