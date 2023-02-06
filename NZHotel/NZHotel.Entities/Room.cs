using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities
{
    public class Room : BaseEntity
    {
        public decimal RoomPrice { get; set; }
        public int RoomNo { get; set; }
        public string BedInfo { get; set; }
        public string RoomName { get; set; }
        public string Info { get; set; } // Ch in ch out infor will be shown 
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public string RoomPhotoPath { get; set; }
        public DateTime? ReparingFinishDate { get; set; }

        //Navigational Prop Begins
        public int? RoomDetailId { get; set; }
        public RoomDetail RoomDetail { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int CleaningStatusId { get; set; }
        public CleaningStatus CleaningStatus { get; set; }
        public int RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }
    }
}
