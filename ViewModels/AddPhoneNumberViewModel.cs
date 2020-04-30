﻿using System.ComponentModel.DataAnnotations;

namespace SchoolsPortal.ViewModels
{
	public class AddPhoneNumberViewModel
	{
		[Required(ErrorMessage = "وارد کردن {0} الزامی است")]
		[Phone]
		[Display(Name = "شماره موبایل")]
		public string PhoneNumber { get; set; }
	}
}