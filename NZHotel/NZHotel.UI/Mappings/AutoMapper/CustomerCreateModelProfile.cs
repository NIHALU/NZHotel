using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class CustomerCreateModelProfile : Profile
    {
        public CustomerCreateModelProfile()
        {
            CreateMap<CustomerCreateModel, CustomerCreateDto>().ReverseMap();

        }
    }
}
