﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NZHotel.Business.Mappings.AutoMapper;

namespace NZHotel.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile> {
                new RoomProfile(),
                new RoomStatusProfile(),
                new RoomTypeProfile(),
                new RoomDetailProfile(),
                new ReservationProfile(),
                new ReservationOptionProfile(),
                new CleaningStatusProfile(),
                new CustomerProfile(),
                new GuestProfile(),
                new GuestInfoProfile(),
                new PaymentTypeProfile(),
                new PaymentStatusProfile(),
                new ReservationTypeProfile(),
                new GuestTypeProfile(),
                new GenderProfile(),
                new GuestReservationProfile(),
                new DepartmentProfile(),
                new EmployeeProfile(),
                new EmployeeFileProfile(),
                new ShiftProfile(),
                new WorkingTypeProfile()

            };
        }
    }
}
