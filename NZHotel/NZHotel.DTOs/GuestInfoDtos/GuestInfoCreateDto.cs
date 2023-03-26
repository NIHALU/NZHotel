﻿using NZHotel.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.DTOs
{
    public class GuestInfoCreateDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

        public int Age { get; set; }

        public int GuestTypeId { get; set; }
        public int ReservationId { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
    }
}
