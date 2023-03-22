using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common;
using NZHotel.Common.Enums;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Interfaces
{
    public interface IRoomService : IService<RoomCreateDto, RoomUpdateDto, RoomListDto, Room>
    {
        Task<List<RoomListDto>> Getlist();
    
        Task<RoomListDto> GetFilteredRoom(int number);

        Task<List<RoomListDto>> GetNotBookedRoomList(BookRoomCreateDto dto,params int[] list);
       
    }
        
}
