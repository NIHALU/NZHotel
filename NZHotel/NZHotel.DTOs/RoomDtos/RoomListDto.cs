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
        public decimal EarlyBookingDisRate { get; set; }
        public decimal DiscountedAmount => MainAmount - (MainAmount * (EarlyBookingDisRate / 100));

        public decimal PaymentDifference { get; set; }

        public string ReservationOption { get; set; }
        public decimal CalculateMainAmount(int childrenCount, int infantCount, int numberofDays)
        {
            decimal roomPrice = RoomPrice;
            decimal perChildDiscount = 10;
            decimal totalChildDiscount = 0;
            decimal perInfantPrice = 8;
            decimal totalInfantPrice = 0;


            if (childrenCount > 0 && infantCount >= 1) //hem çocuk hem infant oldugu durum
            {
                totalChildDiscount = perChildDiscount * childrenCount;
                totalInfantPrice = perInfantPrice * (infantCount - 1);
                roomPrice = roomPrice - (roomPrice * (totalChildDiscount / 100)) + (roomPrice * (totalInfantPrice / 100));

            }
            else if (childrenCount>0 && infantCount <1)   //çocuk var infant yok
            {
                totalChildDiscount = perChildDiscount * childrenCount;
                roomPrice = roomPrice - (roomPrice * (totalChildDiscount / 100));
            }
            else if(childrenCount==0 && infantCount>=1 )  //çocuk yok infsnt var
			{
                totalInfantPrice = perInfantPrice * (infantCount - 1);
                roomPrice = roomPrice + (roomPrice * (totalInfantPrice / 100));
            }

            //ne çocuk ne infant var sadece adult
            return roomPrice * numberofDays;

        }

        public decimal CalculatePaymentDifference(decimal oldAmount)
        {
            decimal paymentDifference = 0;
            
           return paymentDifference = Convert.ToDecimal((DiscountedAmount - oldAmount));
           
        }




    }
}
