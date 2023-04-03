using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class EmployeeFileUpdateModelProfile:Profile
    {
        public EmployeeFileUpdateModelProfile()
        {
            CreateMap<EmployeeFileUpdateModel, EmployeeFileUpdateDto>().ReverseMap();
        }
    }
}
