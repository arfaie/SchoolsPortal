using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            var model = new MultiModels();
            model.AboutUs = _context.AboutUses.FirstOrDefault();
            model.ContactUses = await _context.ContactUses.ToListAsync();
            model.Galleries = await _context.Galleries.ToListAsync();
            model.Services = _context.Serviceses.SingleOrDefault();
            model.Sliders = await _context.Sliders.ToListAsync();
            model.Setting = _context.Settings.SingleOrDefault();
            ViewBag.RootPath = "/images/home-uploads/";

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
