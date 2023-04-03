using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Mappings.AutoMapper
{
    public class WorkingTypeProfile:Profile
    {
        public WorkingTypeProfile()
        {
            CreateMap<WorkingType, WorkingTypeListDto>().ReverseMap();
            CreateMap<WorkingType, WorkingTypeUpdateDto>().ReverseMap();
            CreateMap<WorkingType, WorkingTypeCreateDto>().ReverseMap();
        }
    }
}
