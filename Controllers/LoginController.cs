// Controllers/LoginController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class LoginController : Controller
{
    private readonly ApplicationDbContext _context;

    public LoginController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Login
    public ActionResult Index()
    {
        return View();
    }
    public IActionResult UserInformation()
    {
        var users = _context.UserInfo.ToList();
        RedirectToAction("UserInformation", "Home");
        return View(users);
    }

    // POST: /Login/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginView loginView)
    {
        if (ModelState.IsValid)
        {
            // Check if the user with the provided email and password exists
            var user = _context.UserInfo.FirstOrDefault(u => u.Email == loginView.Email && u.Password == loginView.Password);

            if (user != null)
            {
                // Login successful, redirect to Information action
                return RedirectToAction("UserInformation", "Home");

            }
            else
            {
                // Invalid credentials, return to the login view
                ModelState.AddModelError("", "Invalid login attempt");
                return RedirectToAction("userLogin", "Home");

            }
        }

        // If ModelState is not valid, return to the login view
        return View("Index");
    }

}
