using CRUD.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;



namespace CRUD.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private readonly ApplicationDbContext _context;

        public AccountController(IAccountService accountService, ApplicationDbContext context)
        {
            _accountService = accountService;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }
        public IActionResult registration()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email_Account, string Password)
        {
            var account = _accountService.Login(Email_Account,Password);
            if (account!=null)
            {
                HttpContext.Session.SetString("username", Email_Account);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Login";
                return View();
            }
            return View();

        }
        public IActionResult Logout()
        {
            // Remove the "username" session key
            HttpContext.Session.Remove("username");

            // Clear all cookies related to the session
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            // Return to the login page
            return RedirectToAction("Index", "Account");
        }


        [HttpPost]
        public IActionResult Register(UserAccount useracc)
        {
            if (ModelState.IsValid)
            {
                // Add user details to the database
                _context.UserAccount.Add(useracc);
                _context.SaveChanges();

                // Redirect to a success page or another action
                return RedirectToAction("Index", "Account");
            }

            // If ModelState is not valid, redisplay the registration form with validation errors
            return RedirectToAction("registration", "Account");
        }

    }
}
