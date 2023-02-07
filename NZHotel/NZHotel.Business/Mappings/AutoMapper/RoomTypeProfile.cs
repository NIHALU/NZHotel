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
    public class RoomTypeProfile:Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomType, RoomTypeListDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeUpdateDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeCreateDto>().ReverseMap();
        }
    }
}
