using AutoMapper;
using NZHotel.DTOs;

namespace NZHotel.UI.Mappings.AutoMapper
{
    public class BookRoomCreateModelProfile:Profile
    {
        public BookRoomCreateModelProfile()
        {
            CreateMap<BookRoomModel, BookRoomCreateDto>().ReverseMap();
        }
    }
}
