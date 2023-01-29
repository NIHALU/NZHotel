using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.EmployeeDetailDtos
{
    public class EmployeeUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int GenderId { get; set; }
    }
}
