using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;
using System;
using TestApp.Data;
using TestApp.Migrations;
using TestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly TestAppDBContext _db;

        public ContactController(TestAppDBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Contacts.ToListAsync());
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(СontactViewModel obj)
        //{
        //    if (obj.CBirthDate.Date > DateTime.Now || obj.CBirthDate.Date < DateTime.Now.AddYears(-150))
        //    {
        //        ModelState.AddModelError("cBirthDate", "Input valid Birth date");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _db.Contacts.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}

        public IActionResult CreateOrEdit(int? id)
        {
            if (id == 0 || id==null)
            {
                return View(new СontactViewModel() { Id = 0 });
            }
            else
            {
                var contact = _db.Contacts.Find(id);

                if (contact == null)
                {
                    return NotFound();
                }
                return View(contact);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrEdit(СontactViewModel obj)
        {
            if (obj.CBirthDate.Date > DateTime.Now || obj.CBirthDate.Date < DateTime.Now.AddYears(-150))
            {
                ModelState.AddModelError("cBirthDate", "Input valid Birth date");
            }

            if (ModelState.IsValid)
            {

                if (obj.Id == 0 || obj.Id == null)
                {
                    _db.Contacts.Add(obj);
                }
                else
                {
                    _db.Contacts.Update(obj);
                }
                _db.SaveChanges();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewMain", _db.Contacts) }); ;
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", obj) });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            СontactViewModel contact = _db.Contacts.Find(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

