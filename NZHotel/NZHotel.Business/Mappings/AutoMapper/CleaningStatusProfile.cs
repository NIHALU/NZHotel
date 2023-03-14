using AutoMapper;
using NZHotel.DTOs;
using NZHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.Mappings.AutoMapper
{
    public class CleaningStatusProfile: Profile
    {
        public CleaningStatusProfile()
        {
            CreateMap<CleaningStatus, CleaningStatusListDto>().ReverseMap();
            CreateMap<CleaningStatus, CleaningStatusUpdateDto>().ReverseMap();
            CreateMap<CleaningStatus, CleaningStatusCreateDto>().ReverseMap();
        }
    }
}
