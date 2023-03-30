using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.DepartmentDtos;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
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
        public bool Active { get; set; }
        public string Title { get; set; }

        public GenderListDto Gender { get; set; }
        public int GenderId { get; set; }
        public int DepartmentId { get; set; }

        public DepartmentListDto Department { get; set; }
    }
}
