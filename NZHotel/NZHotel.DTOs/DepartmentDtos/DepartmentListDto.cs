using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.DepartmentDtos
{
    public class DepartmentListDto:IDto
    {
        public int  Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; } 
    }
}
