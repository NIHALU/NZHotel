using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NZHotel.UI.Areas.Management.Models
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter email format.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public SelectList Roles { get; set; }
        public int RoleId { get; set; }

    }
}
