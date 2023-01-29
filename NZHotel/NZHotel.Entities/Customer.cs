﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class Customer:BaseEntity
    {
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public bool IsTurkish { get; set; }
        public string TurkishIDNo{ get; set; }
        public string PassportNo { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }

  
        public List <Reservation> Reservations { get; set; }
    }
}
