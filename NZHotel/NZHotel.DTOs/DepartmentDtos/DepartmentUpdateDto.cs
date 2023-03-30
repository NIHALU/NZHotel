using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.DepartmentDtos
{
    public class DepartmentUpdateDto : IUpdateDto
    {
        public int Id { get ; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
    }
}
