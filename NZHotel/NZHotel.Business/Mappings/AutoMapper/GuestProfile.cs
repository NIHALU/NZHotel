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
    public class GuestProfile:Profile
    {
        public GuestProfile()
        {
            CreateMap<GuestCreateDto, Guest>().ReverseMap();
            CreateMap<GuestListDto, Guest>().ReverseMap();
            CreateMap<GuestUpdateDto, Guest>().ReverseMap();
        }
    }
}
