﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class GuestReservation
    {
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
