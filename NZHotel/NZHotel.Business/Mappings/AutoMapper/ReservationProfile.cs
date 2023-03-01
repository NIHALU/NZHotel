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
    public class ReservationProfile:Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationListDto>().ReverseMap();
            CreateMap<Reservation, ReservationUpdateDto>().ReverseMap();
            CreateMap<Reservation, ReservationCreateDto>().ReverseMap();
        }
    }
}
