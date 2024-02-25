using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD.Controllers

{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeCreate()
        {
            return View();
        }
        public IActionResult userLogin()
        {
            return View();
        }
        public IActionResult registration()
        {
            return View();
        }

        public IActionResult UserInformation()
        {
            var users = _context.UserInfo.ToList();
            return View(users);
        }
        public IActionResult Department()
        {
            var dept = _context.Departments.ToList();
            return View(dept);
        }
        public IActionResult Employee()
        {
            var employee = _context.Employee.ToList();
            return View(employee);
        }
        public IActionResult Designation()
        {
            var designated = _context.Designation.ToList();
            return View(designated);
        }
        public IActionResult UserAccount()
        {
            var userAcc = _context.UserAccount.ToList();
            return View(userAcc);
        }

        // Update
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
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // HomeController.cs
        public IActionResult Delete(int id)
        {
            return PartialView("_DeleteConfirmation", id);
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

            return RedirectToAction(nameof(Employee)); ;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
