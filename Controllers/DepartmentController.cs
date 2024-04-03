using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
namespace CRUD.Controllers

{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult DepartmentCreate()
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
        public IActionResult Create(Department department)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (ModelState.IsValid)
                {
                    // Add user details to the database
                    _context.Departments.Add(department);
                    _context.SaveChanges();
                    // Redirect to a success page or another action
                    return RedirectToAction("Department", "Department");
                }

                // If ModelState is not valid, redisplay the registration form with validation errors
                return RedirectToAction("DepartmentCreate", "Department");
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        // READ
        public IActionResult Department()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                var department = _context.Departments.ToList();
                return View(department);
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

                var department = _context.Departments.Find(id);
                if (department == null)
                {
                    return NotFound();
                }
                return View(department);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
               
                if (id != department.Department_Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Update(department);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Department));
                }
                return View(department);
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
                var deptDel = _context.Departments.Find(id);
                _context.Departments.Remove(deptDel);
                if (deptDel == null)
                {
                    return NotFound();
                }

                return View(deptDel);
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
                var department = _context.Departments.Find(id);
                if (department == null)
                {
                    return NotFound();
                }

                _context.Departments.Remove(department);
                _context.SaveChanges();

                return RedirectToAction(nameof(Department));
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
    }
}
