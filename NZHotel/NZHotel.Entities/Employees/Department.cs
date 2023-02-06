using System;
using System.Collections.Generic;
using NZHotel.Common.Enums;

namespace NZHotel.Entities
{
    public class Department:BaseEntity
    {
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Employees.Employee> Employees { get; set; }
    }
}
