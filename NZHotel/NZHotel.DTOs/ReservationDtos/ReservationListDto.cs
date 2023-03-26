using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{

    public class ReservationListDto:IDto
    {
        public int Id { get; set; }
        public int NumberofDays { get; set; }
        public int NumberofGuests { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public decimal TotalAmount { get; set; }
        
        public int RoomId { get; set; }
        public RoomListDto Room { get; set;}
        public int CustomerId { get; set; }

        public CustomerListDto Customer { get; set; }
        public int ReservationOptionId { get; set; }
        public ReservationOptionListDto ReservationOption { get; set; }
        public int PaymentStatusId { get; set; }

        public PaymentStatusListDto PaymentStatus { get; set; }

        public int ReservationTypeId { get; set; }

        public ReservationTypeListDto ReservationType { get; set; }

        public int PaymentTypeId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public string ReservationCode { get; set; }

    }
}
