﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public int? MaxChildren { get; set; }
        public int? MaxInfants { get; set; }
     
        [NotMapped]
        public IEnumerable<IFormFile> Image { get; set; }


        //Navigational Prop Begins
        public List<Image> Images { get; set; }
        public int? RoomDetailId { get; set; }
        public RoomDetail RoomDetail { get; set; }

        public List<Reservation> Reservations { get; set; } 
        //lookup
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int? CleaningStatusId { get; set; }
        public CleaningStatus CleaningStatus { get; set; }
        public int RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }

    }
}
