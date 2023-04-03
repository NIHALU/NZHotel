using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Interfaces
{
    public interface IGuestReservationService : IService<GuestReservationCreateDto, GuestReservationUpdateDto, GuestReservationListDto, GuestReservation>
    {
        Task<List<GuestReservationListDto>> CheckInOutList();
        Task<List<GuestReservationListDto>> GetReservations(int guestId);
    }
}
