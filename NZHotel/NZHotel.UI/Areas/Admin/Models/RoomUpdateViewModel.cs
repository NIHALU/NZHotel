using Microsoft.AspNetCore.Mvc.Rendering;

namespace NZHotel.UI.Areas.Admin.Models
{
    public class RoomUpdateViewModel
    {
        public int Id { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public decimal RoomPrice { get; set; }
        public int RoomNo { get; set; }
        public string Info { get; set; }
        public int RoomTypeId { get; set; }
        public string BedInfo { get; set; }
        public string RoomName { get; set; }
        public int RoomStatusId { get; set; }
        public int CleaningStatusId { get; set; }
        public SelectList RoomTypes { get; set; }
        public SelectList RoomStatuses { get; set; }
        public SelectList CleaningStatuses { get; set; }


    }
}
