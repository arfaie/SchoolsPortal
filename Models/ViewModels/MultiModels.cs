using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolsPortal.Models.ViewModels
{
    public class MultiModels
    {
        public AboutUs AboutUs { get; set; }
        public List<ContactUs> ContactUses { get; set; }
        public List<Gallery> Galleries { get; set; }
        public Services Services { get; set; }
        public List<Slider> Sliders { get; set; }
        public Setting Setting { get; set; }
    }
}
