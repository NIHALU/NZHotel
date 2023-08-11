using System.ComponentModel.DataAnnotations;

namespace NZHotel.UI.Models
{
	public class ChangePasswordModel
	{
		[Required]
		[DataType(DataType.Password)]
		public string CurrentPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Compare("NewPassword",ErrorMessage ="New password and confirm password do not match!")]
		public string ConfirmPassword { get; set;}

	}
}
