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
    public class ShiftProfile:Profile
    {
        public ShiftProfile()
        {
            CreateMap<Shift, ShiftListDto>().ReverseMap();
            CreateMap<Shift, ShiftUpdateDto>().ReverseMap();
            CreateMap<Shift, ShiftCreateDto>().ReverseMap();
        }
    }
}
