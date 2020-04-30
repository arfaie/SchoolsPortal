using System.ComponentModel.DataAnnotations;

namespace SchoolsPortal.ViewModels
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required(ErrorMessage = "وارد کردن {0} الزامی است")]
		[EmailAddress]
		public string Email { get; set; }
	}
}