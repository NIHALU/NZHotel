﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.Interfaces
{
    public interface IReservationService : IService<ReservationCreateDto, ReservationUpdateDto, ReservationListDto, Reservation>
    {
        Task<ArrayList> GetBokeedRoomList(RoomBookCreateDto dto);
    }
}