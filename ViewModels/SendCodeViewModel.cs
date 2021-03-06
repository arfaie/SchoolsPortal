﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SchoolsPortal.ViewModels
{
	public class SendCodeViewModel
	{
		public string SelectedProvider { get; set; }

		public ICollection<SelectListItem> Providers { get; set; }

		public bool RememberMe { get; set; }
	}
}