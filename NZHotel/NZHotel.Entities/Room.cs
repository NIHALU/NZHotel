using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities
{
    public class Room: BaseEntity
    {
       public int Capacity { get; set; }
       public int RoomPrice { get; set; }
       public int RoomNo { get; set; }
       public DateTime EnteranceDate { get; set; }
       public DateTime ExistDate { get; set; }
       public RoomTypes RoomTypes { get; set; } 
       public RoomStatus RoomStatus { get; set; }
       public PaymentStatus  PaymentStatus { get; set; }
       //Navigational Prop Begins
       public int RoomDetailsId { get; set; }
       public RoomDetails RoomDetails { get; set; }
       public int ReservationId { get; set; }
       public Reservation Reservation { get; set; }
    }
}
