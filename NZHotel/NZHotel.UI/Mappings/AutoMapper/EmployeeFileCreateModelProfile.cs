using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class EmployeeFileCreateModelProfile:Profile
    {
        public EmployeeFileCreateModelProfile()
        {
            CreateMap<EmployeeFileCreateModel, EmployeeFileCreateDto>().ReverseMap();
        }
    }
}
