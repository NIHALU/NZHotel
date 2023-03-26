using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.BookRoomDtos
{
   public class BookRoomUpdateDto:IDto
    {
        
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public int ReservationOptionId { get; set; }

        public int NumberofDays { get; set; }
        public int EarlyBookingDay { get; set; }

        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }

        public int RoomId { get; set; }
        public int ReservationId { get;set; }
        public decimal OldAmount { get; set; }

        public decimal CalculateDiscountRate()
        {
            if (EarlyBookingDay >= 30 && EarlyBookingDay < 90 && ReservationOptionId == (int)ReservationOption.AllInclusive)
            {
                return 18;
            }
            if (EarlyBookingDay >= 30 && EarlyBookingDay < 90 && ReservationOptionId == (int)ReservationOption.FullPansion)
            {
                return 16;
            }
            if (EarlyBookingDay >= 90)
            {
                return 23;
            }

            return 0;
        }
    }
}
