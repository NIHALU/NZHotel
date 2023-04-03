using System.ComponentModel.DataAnnotations;

namespace NZHotel.UI.Areas.Management.Models
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter email format.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
    }
}
