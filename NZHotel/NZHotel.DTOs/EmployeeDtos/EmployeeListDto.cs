using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.EmployeeDtos
{
    public class EmployeeListDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int GenderId { get; set; }
    }
}
