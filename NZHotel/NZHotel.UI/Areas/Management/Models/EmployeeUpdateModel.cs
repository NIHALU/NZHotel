using Microsoft.AspNetCore.Mvc.Rendering;

namespace NZHotel.UI.Areas.Management.Models
{
    public class EmployeeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; }
        public int GenderId { get; set; }

        public int DepartmentId { get; set; }

        public SelectList Genders { get; set; }

        public SelectList Departments { get; set; }
    }
}
