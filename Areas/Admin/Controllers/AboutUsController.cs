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
            return View(await _context.AboutUses.ToListAsync());
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddEdit(string id, AboutUs model, string redirectUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (string.IsNullOrWhiteSpace(id))
        //        {
        //            _context.AboutUses.Add(model);
        //            await _context.SaveChangesAsync();

        //            TempData["Notification"] = Notification.Show(MessageType.Add, type: ToastType.Success, position: ToastPosition.TopRight);
        //            return PartialView("_SuccessfulResponse", redirectUrl);
        //        }

        //        _context.AboutUses.Update(model);
        //        await _context.SaveChangesAsync();

        //        TempData["Notification"] = Notification.Show(MessageType.Edit, type: ToastType.Success, position: ToastPosition.TopRight);
        //        return PartialView("_SuccessfulResponse", redirectUrl);
        //    }

        //    return PartialView("AddEdit", model);
        //}

        [HttpPost]
        public async Task<IActionResult> AddEdit(string id, string Title1, string Title2, string Title3, string Title4)
        {

            var aboutus = await _context.AboutUses.FirstOrDefaultAsync(x => x.Id == id);

            if (aboutus == null)
            {
                return Json(new { status = "fail", message = Notification.Show("آیتم پیدا نشد", type: ToastType.Warning) });
            }

            aboutus.Title1 = Title1;
            aboutus.Title2 = Title2;
            aboutus.Title3 = Title3;
            aboutus.Title4 = Title4;
           

            _context.AboutUses.Update(aboutus);

            try
            {
                await _context.SaveChangesAsync();

                return Json(new { status = "fail", message = Notification.Show("آیتم با موفقیت ویرایش شد", type: ToastType.Success) });
            }
            catch (Exception e)
            {
                return Json(new { status = "fail", message = Notification.Show("آیتم پیدا نشد", type: ToastType.Error) });
            }
        }

        public JsonResult Delete(string id, string redirectUrl)
        {
            var aboutUs = _context.AboutUses.FirstOrDefault(a => a.Id == id);
            if (aboutUs != null)
            {
                _context.AboutUses.Remove(aboutUs);
                TempData["Notification"] = Notification.Show(MessageType.Delete, type: ToastType.Success, position: ToastPosition.TopRight);
                return Json(new { status = "OK" });

            }
            else
            {
                return Json(new { status = "fail" });
            }

        }
    }
}