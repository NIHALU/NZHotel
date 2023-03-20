using NZHotel.Common.Enums;
using NZHotel.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.DTOs
{
    public class BookRoomCreateDto:IDto
    {
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }
        public int ReservationOptionId { get; set; }

        public int NumberofDays => (FinisingDate - StartingDate).Days;
        public int EarlyBookingDays => (DateTime.Now - StartingDate).Days;

        public int CalculateDiscountRate()
        {
            if (EarlyBookingDays >= 30 && ReservationOptionId == (int)ReservationOption.AllInclusive)
            {
                return 18;
            }
            if (EarlyBookingDays >= 30 && ReservationOptionId == (int)ReservationOption.FullPansion)
            {
                return 16;
            }
            if (EarlyBookingDays >= 90)
            {
                return 23;
            }

            return 0;
        }
    }
}
