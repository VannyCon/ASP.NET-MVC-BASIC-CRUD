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
            return View();
        }
        // CREATE
        [HttpPost]
        public IActionResult Create(Department department)
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

        // READ
        public IActionResult Department()
        {
            var department = _context.Departments.ToList();
            return View(department);
        }
        // UPDATE
        public IActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
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



        // DELETE
        public IActionResult Delete(int id)
        {
            var deptDel = _context.Departments.Find(id);
            _context.Departments.Remove(deptDel);
            if (deptDel == null)
            {
                return NotFound();
            }

            return View(deptDel);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
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
    }
}
