using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class RoomListDto:IDto
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
   
        public RoomStatusListDto RoomStatus{ get; set; }
        public int RoomStatusId { get; set; }

        public CleaningStatusListDto CleaningStatus { get; set; }
        public int CleaningStatusId { get; set; }

        public decimal MainAmount { get; set; }
        public decimal DiscountedAmount { get; set;}
    }
}
