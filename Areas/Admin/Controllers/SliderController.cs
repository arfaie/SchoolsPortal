using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolsPortal.Data;
using SchoolsPortal.Models;

namespace SchoolsPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public SliderController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.RootPath = "/images/home-uploads/";
            return View(await _context.Sliders.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AddEditSlider(string id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(a => a.Id == id);
            if (slider != null)
            {
                return PartialView("AddEditSlider", slider);
            }

            return PartialView("AddEditSlider", new Slider());
        }
    }
}