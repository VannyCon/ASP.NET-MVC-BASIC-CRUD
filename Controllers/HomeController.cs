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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
