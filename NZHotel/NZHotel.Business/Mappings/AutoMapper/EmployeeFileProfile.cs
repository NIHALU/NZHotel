using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NZHotel.DTOs;
using NZHotel.Entities.Employees;

namespace NZHotel.Business.Mappings.AutoMapper
{
    public class EmployeeFileProfile:Profile
    {
        public EmployeeFileProfile()
        {
            CreateMap<EmployeeFile, EmployeeFileListDto>().ReverseMap();
            CreateMap<EmployeeFile, EmployeeFileUpdateDto>().ReverseMap();
            CreateMap<EmployeeFile, EmployeeFileCreateDto>().ReverseMap();
        }
    }
}
