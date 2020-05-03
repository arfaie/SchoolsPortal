using SchoolsPortal.Data;
using SchoolsPortal.Models;
using SchoolsPortal.Models.Helpers;
using SchoolsPortal.Models.Helpers.OptionEnums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolsPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AboutUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutUses.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddEdit(string id)
        {
            var aboutUs = await _context.AboutUses.FirstOrDefaultAsync(a => a.Id == id);
            if (aboutUs != null)
            {
                return PartialView("AddEdit", aboutUs);
            }

            return PartialView("AddEdit", new AboutUs());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(string id, AboutUs model, string redirectUrl)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    _context.AboutUses.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["Notification"] = Notification.Show(MessageType.Add, type: ToastType.Success, position: ToastPosition.TopRight);
                    return PartialView("_SuccessfulResponse", redirectUrl);
                }

                _context.AboutUses.Update(model);
                await _context.SaveChangesAsync();

                TempData["Notification"] = Notification.Show(MessageType.Edit, type: ToastType.Success, position: ToastPosition.TopRight);
                return PartialView("_SuccessfulResponse", redirectUrl);
            }

            return PartialView("AddEdit", model);
        }

        public JsonResult Delete(string id,string redirectUrl)
        {
            var aboutUs =  _context.AboutUses.FirstOrDefault(a => a.Id == id);
            if (aboutUs != null)
            {
                _context.AboutUses.Remove(aboutUs);
                TempData["Notification"] = Notification.Show(MessageType.Delete, type: ToastType.Success, position: ToastPosition.TopRight);
                return Json(new { status = "OK"});

            }
            else
            {
                return Json(new { status = "fail"});
            }

        }
    }
}