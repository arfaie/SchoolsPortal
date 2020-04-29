using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SchoolsPortal.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "کد ملی")]
        public long NationalCode { get; set; }

        [NotMapped]
        [Display(Name = "نقش")]
        public string ApplicationRoleId { get; set; }

        [NotMapped]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
    }
}
