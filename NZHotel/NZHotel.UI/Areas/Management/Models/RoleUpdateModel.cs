using System.ComponentModel.DataAnnotations;

namespace NZHotel.UI.Areas.Management.Models
{
    public class RoleUpdateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string ConcurrencyStamp{ get; set; }



    }
}
