using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class EmployeeUpdateModelProfile:Profile
    {
        public EmployeeUpdateModelProfile()
        {
            CreateMap<EmployeeUpdateModel, EmployeeUpdateDto>().ReverseMap();

        }
    }
}
