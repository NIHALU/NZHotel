using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common;
using NZHotel.DTOs;
using NZHotel.DTOs.BookRoomDtos;
using NZHotel.Entities;

namespace NZHotel.Business.Interfaces
{
    public interface IReservationService : IService<ReservationCreateDto, ReservationUpdateDto, ReservationListDto, Reservation>
    {
        Task<ArrayList> GetBookedRoomList(BookRoomCreateDto dto);
        Task<IResponse<ReservationCreateDto>> CreateReservation(ReservationCreateDto dto);
        Task<bool> CheckUpdateReservation(ReservationUpdateDto dto);
        Task<bool> CheckReservation(ReservationCreateDto dto);
        Task<ReservationListDto> GetReservation(BookRoomCreateDto dto, int roomId);
        Task<IResponse<ReservationUpdateDto>> UpdateReservation(ReservationUpdateDto dto);
        Task<IResponse<List<ReservationListDto>>> GetActiveReservations();
        Task<ArrayList> GetBookedRoomListForUpdate(BookRoomUpdateDto dto);
        
    }
}
