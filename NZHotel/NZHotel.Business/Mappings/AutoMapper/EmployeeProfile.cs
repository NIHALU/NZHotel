using AutoMapper;
using NZHotel.DTOs;
using NZHotel.Entities.Employees;

namespace NZHotel.Business.Mappings.AutoMapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
        }
    }
}
