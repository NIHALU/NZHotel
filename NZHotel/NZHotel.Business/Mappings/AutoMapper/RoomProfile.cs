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
    public class RoomProfile:Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomListDto>().ReverseMap();
            CreateMap<Room, RoomUpdateDto>().ReverseMap();
            CreateMap<Room, RoomCreateDto>().ReverseMap();
        }
    }
}
