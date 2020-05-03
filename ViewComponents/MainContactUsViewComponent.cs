using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolsPortal.Data;

namespace SchoolsPortal.ViewComponents
{
    public class MainContactUsViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public MainContactUsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.RootPath = "images/home-uploads/";

            return View(await _context.ContactUses.AsNoTracking().ToListAsync());
        }
    }
}
