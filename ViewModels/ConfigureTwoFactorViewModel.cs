﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SchoolsPortal.ViewModels
{
	public class ConfigureTwoFactorViewModel
	{
		public string SelectedProvider { get; set; }

		public ICollection<SelectListItem> Providers { get; set; }
	}
}