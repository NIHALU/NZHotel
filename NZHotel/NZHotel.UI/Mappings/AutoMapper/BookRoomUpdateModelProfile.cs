using AutoMapper;
using NZHotel.DTOs.BookRoomDtos;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class BookRoomUpdateModelProfile:Profile
    {
        public BookRoomUpdateModelProfile()
        {
            CreateMap<BookRoomUpdateModel, BookRoomUpdateDto>().ReverseMap();
        }
    }
}
