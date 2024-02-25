using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Other action methods...

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Add user details to the database
                _context.Employee.Add(employee);
                _context.SaveChanges();

                // Redirect to a success page or another action
                return RedirectToAction("Employee", "Home");
            }

            // If ModelState is not valid, redisplay the registration form with validation errors
            return RedirectToAction("EmployeeCreate", "Home");
        }
    }
}
