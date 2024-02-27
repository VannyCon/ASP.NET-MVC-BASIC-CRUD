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
            return View();
        }
        // CREATE
        [HttpPost]
        public IActionResult Create(Employee employee)
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
        // READ
        public IActionResult Employee()
        {
            var employee = _context.Employee.ToList();
            return View(employee);
        }
        // UPDATE
        public IActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
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


        // DELETE
        public IActionResult Delete(int id)
        {
            var employee = _context.Employee.Find(id);
            _context.Employee.Remove(employee);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
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


    }
}
