using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace CRUD.Controllers

{
    public class EmployeeController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult EmployeeCreate()
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
        public IActionResult Create(Employee employee)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (ModelState.IsValid)
                {
                    // Add user details to the database
                    _context.Employee.Add(employee);
                    _context.SaveChanges();
                    // Redirect to a success page or another action
                    return RedirectToAction("Employee", "Employee");
                }

                // If ModelState is not valid, redisplay the registration form with validation errors
                return RedirectToAction("EmployeeCreate", "Employee");
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
           
        }
        // READ
        public IActionResult Employee()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");

            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                var employee = _context.Employee.ToList();
                return View(employee);
            }
            else {
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

                var employee = _context.Employee.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (id != employee.Employee_Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Employee));
                }
                return View(employee);
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
                var employee = _context.Employee.Find(id);
                _context.Employee.Remove(employee);
                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
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
                var employee = _context.Employee.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                _context.Employee.Remove(employee);
                _context.SaveChanges();

                return RedirectToAction(nameof(Employee));
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }


        }


    }
}
