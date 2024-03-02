using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DesignationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult DesignationCreate()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        // CREATE
        [HttpPost]
        public IActionResult Create(Designation designation)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (ModelState.IsValid)
                {
                    // Add user details to the database
                    _context.Designation.Add(designation);
                    _context.SaveChanges();
                    // Redirect to a success page or another action
                    return RedirectToAction("Designation", "Designation");
                }

                // If ModelState is not valid, redisplay the registration form with validation errors
                return RedirectToAction("DesignationCreate", "Designation");
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        // READ
        public IActionResult Designation()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                var designation = _context.Designation.ToList();
                return View(designation);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        // UPDATE
        public IActionResult Edit(int? id)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var designation = _context.Designation.Find(id);
                if (designation == null)
                {
                    return NotFound();
                }
                return View(designation);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Designation designation)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (id != designation.Designation_Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Update(designation);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Designation));
                }
                return View(designation);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }


        // DELETE
        public IActionResult Delete(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                var designated = _context.Designation.Find(id);
                _context.Designation.Remove(designated);
                if (designated == null)
                {
                    return NotFound();
                }

                return View(designated);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                var designated = _context.Designation.Find(id);
                if (designated == null)
                {
                    return NotFound();
                }

                _context.Designation.Remove(designated);
                _context.SaveChanges();

                return RedirectToAction(nameof(Designation));
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
    }
}
