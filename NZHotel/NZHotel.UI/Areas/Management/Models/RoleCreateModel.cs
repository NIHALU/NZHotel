using System.ComponentModel.DataAnnotations;

namespace NZHotel.UI.Areas.Management.Models
{
    public class RoleCreateModel
    {
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
    }
}
