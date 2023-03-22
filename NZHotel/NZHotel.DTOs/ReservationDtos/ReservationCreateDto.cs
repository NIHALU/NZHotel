﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class ReservationCreateDto:IDto
    {
        public int NumberofGuests { get; set; }
        public int NumberofDays { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Active { get; set; } = true;

       
        public int RoomId { get; set; }
    
        public int CustomerId { get; set; }
      
        public int ReservationOptionId { get; set; }
        
        public int PaymentStatusId { get; set; }
       
        public int ReservationTypeId { get; set; }
       
        

    }
}
