﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class RoomDetailUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public int FloorInfo { get; set; }
        public bool HasWifi { get; set; }
        public bool HasMinibar { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasSeaView { get; set; }
        public bool HasAC { get; set; }
        public bool HasTV { get; set; }
        public bool HasHairDryer { get; set; }
        public bool HasLivingRoom { get; set; }
        public bool HasWashingMashine { get; set; }
        public bool HasSafeDepositBox { get; set; }
        public bool HasJakuzi { get; set; }
        public int RoomId { get; set; }
    }
}
