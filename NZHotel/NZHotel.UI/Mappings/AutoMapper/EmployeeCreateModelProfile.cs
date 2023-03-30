using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class EmployeeCreateModelProfile:Profile
    {
        public EmployeeCreateModelProfile()
        {
            CreateMap<EmployeeCreateModel, EmployeeCreateDto>().ReverseMap();
        }

    }
}
