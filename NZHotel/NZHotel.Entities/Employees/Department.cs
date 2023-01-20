﻿using System;
using System.Collections.Generic;
using NZHotel.Common.Enums;

namespace NZHotel.Entities
{
    public class Department:BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; } = Status.Active; 
        public List<Employees.Employee> Employees { get; set; }
    }
}
