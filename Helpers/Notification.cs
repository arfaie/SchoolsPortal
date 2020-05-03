using SchoolsPortal.Models.Helpers.OptionEnums;
using System;
using System.ComponentModel;
using System.Reflection;

namespace SchoolsPortal.Models.Helpers
{
	public static class Notification
	{
		#region HELPERS

		private static string StringValueOf(Enum value)
		{
			var fi = value.GetType().GetField(value.ToString());
			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (attributes.Length > 0)
			{
				return attributes[0].Description;
			}

			return value.ToString();
		}

		private static string BooToLowerString(this bool value)
		{
			return value.ToString().ToLower();
		}

        #endregion HELPERS

        public static string Show(string message, string title = "",
            ToastType type = ToastType.Info,
            ToastPosition position = ToastPosition.TopRight,
            int timeOut = 6000,
            bool closeButton = true,
            bool progressBar = true,
            bool newestOnTop = true,
            string onclick = null)
        {
            var scriptOption = "<script>";
            scriptOption += "toastr.options = {";

            scriptOption += "'closeButton': '" + closeButton.booToLowerString() + "','debug': false,'newestOnTop': " + newestOnTop.booToLowerString() + ",'progressBar': " + progressBar.booToLowerString() + ",'positionClass': '" + stringValueOf(position) + "','preventDuplicates': false,'onclick': " + (onclick ?? "null") + ",'showDuration': '300','hideDuration': '1000','timeOut': '" + timeOut + "','extendedTimeOut': '1000','showEasing': 'swing','hideEasing': 'linear','showMethod': 'fadeIn','hideMethod': 'fadeOut'";
            scriptOption += "};";
            scriptOption += "toastr['" + stringValueOf(type) + "']('" + message + "', '" + title + "');</script>";

            return scriptOption;
        }
        private static string booToLowerString(this bool value)
        {
            return value.ToString().ToLower();
        }
        private static string stringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        public class JsonData
        {
            public string Script { get; set; }
            public string Html { get; set; }
            public bool Success { get; set; }
            public string Option { get; set; }
            public string Url { get; set; }
            public bool IsUsed { get; set; }
        }
    }
}