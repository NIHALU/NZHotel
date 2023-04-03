﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace NZHotel.UI.Areas.Management.Models
{
    public class ShiftCreateModel
    {
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Evening { get; set; }

        public int EmployeeId { get; set; }

        public SelectList Employees { get; set; }

    }
}
