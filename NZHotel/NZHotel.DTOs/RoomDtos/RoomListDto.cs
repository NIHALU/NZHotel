using NZHotel.Common.Enums;
using NZHotel.DTOs.Interfaces;
using System;

namespace NZHotel.DTOs
{
    public class RoomListDto : IDto
    {
        public int Id { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int MaxInfants { get; set; }
        public decimal RoomPrice { get; set; }
        public int RoomNo { get; set; }
        public string Info { get; set; }
        public RoomTypeListDto RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public string BedInfo { get; set; }
        public string RoomName { get; set; }

        public RoomStatusListDto RoomStatus { get; set; }
        public int RoomStatusId { get; set; }

        public CleaningStatusListDto CleaningStatus { get; set; }
        public int CleaningStatusId { get; set; }

        public decimal MainAmount { get; set; }
        public int EarlyBookingDisRate { get; set; }
        public decimal DiscountedAmount => MainAmount - (MainAmount * (EarlyBookingDisRate / 100));


        public decimal CalculateMainAmount(int childrenCount, int infantCount, int numberofDays)
        {
            decimal roomPrice = RoomPrice;
            decimal perChildDiscount = roomPrice * 10 / 100;
            decimal totalChildDiscount = 0;
            decimal perInfantPrice = roomPrice * 8 / 100;
            decimal totalInfantPrice = 0;


            if (childrenCount > 0)
            {
                totalChildDiscount = perChildDiscount * childrenCount;
                roomPrice -= roomPrice * totalChildDiscount;

            }
            if (infantCount > 0)
            {
                if (infantCount > 1)
                {
                    totalInfantPrice = perInfantPrice * infantCount - 1;
                    roomPrice += totalInfantPrice;
                }

            }

            return roomPrice * numberofDays;

        }

        


    }
}
