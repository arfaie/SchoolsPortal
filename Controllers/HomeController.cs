using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolsPortal.Data;
using SchoolsPortal.Models;
using SchoolsPortal.Models.ViewModels;

namespace SchoolsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new MultiModels();
            model.AboutUs = _context.AboutUses.FirstOrDefault();
            model.ContactUses =
                (from contactUse in _context.ContactUses select contactUse).ToList();
            model.Galleries =
                (from gallery in _context.Galleries orderby gallery.Id descending select gallery).ToList();
            model.Services = _context.Serviceses.SingleOrDefault();
            model.Sliders = (from slider in _context.Sliders orderby slider.Id select slider).ToList();
            model.Setting = _context.Settings.SingleOrDefault();
            ViewBag.RootPath = "images/home-uploads/";

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
