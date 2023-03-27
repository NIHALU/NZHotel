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
    public class GuestReservationProfile:Profile
    {
        public GuestReservationProfile()
        {
            CreateMap<GuestReservation, GuestReservationListDto>().ReverseMap();
            CreateMap<GuestReservation, GuestReservationUpdateDto>().ReverseMap();
            CreateMap<GuestReservation, GuestReservationCreateDto>().ReverseMap();
        }
    }
}
