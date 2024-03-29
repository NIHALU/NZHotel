﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;


namespace NZHotel.Entities.Employees
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; } = true;

     


        //lookuptable
        public int GenderId { get; set; }
        public Gender Gender { get; set; }


        //Navigational Prop Begins
        public int EmployeeFileId { get; set; }
        public EmployeeFile EmployeeFile { get; set; }

        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

  
 
        
    }
}
