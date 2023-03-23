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
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<PaymentType, PaymentTypeListDto>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeUpdateDto>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeCreateDto>().ReverseMap();
        }
    }
}
