using AutoMapper;
using NZHotel.DTOs;
using NZHotel.UI.Areas.Member.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class BookingRoomModelProfile:Profile
    {
        public BookingRoomModelProfile()
        {
            CreateMap<BookingRoomModel, BookRoomCreateDto>().ReverseMap();
        }
    }
}
