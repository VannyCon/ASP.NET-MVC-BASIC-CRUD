// Controllers/RegistrationController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class RegistrationController : Controller
{
    private readonly ApplicationDbContext _context;

    public RegistrationController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Other action methods...

    [HttpPost]
        public IActionResult Register(UserDetails UserDetails)
        {
            if (ModelState.IsValid)
            {
                // Add user details to the database
                _context.UserInfo.Add(UserDetails);
                _context.SaveChanges();

            // Redirect to a success page or another action
                return RedirectToAction("userLogin", "Home");
        }

        // If ModelState is not valid, redisplay the registration form with validation errors
                return RedirectToAction("registration", "Home");
    }
    }
