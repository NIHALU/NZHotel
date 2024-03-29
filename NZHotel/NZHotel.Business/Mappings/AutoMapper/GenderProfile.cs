﻿using AutoMapper;
using NZHotel.DTOs;
using NZHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.Mappings.AutoMapper
{
    public class GenderProfile:Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderListDto>().ReverseMap();
        }
    }
}
