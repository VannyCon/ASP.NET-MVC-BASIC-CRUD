using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace CRUD.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserAccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult UserAccountCreate()
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
        public IActionResult userCreate(UserAccount userAcc)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (ModelState.IsValid)
                {
                    // Add user details to the database
                    _context.UserAccount.Add(userAcc);
                    _context.SaveChanges();
                    // Redirect to a success page or another action
                    return RedirectToAction("UserAccount", "UserAccount");
                }

                // If ModelState is not valid, redisplay the registration form with validation errors
                return RedirectToAction("UserAccountCreate", "UserAccount");
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        // READ
        public IActionResult UserAccount()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                var userAcc = _context.UserAccount.ToList();
                return View(userAcc);
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

                var userAcc = _context.UserAccount.Find(id);
                if (userAcc == null)
                {
                    return NotFound();
                }
                return View(userAcc);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserAccount userAcc)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                if (id != userAcc.UserAccount_Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Update(userAcc);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(UserAccount));
                }
                return View(userAcc);
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
                var userAccount = _context.UserAccount.Find(id);
                _context.UserAccount.Remove(userAccount);
                if (userAccount == null)
                {
                    return NotFound();
                }

                return View(userAccount);
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
                var userAccount = _context.UserAccount.Find(id);
                if (userAccount == null)
                {
                    return NotFound();
                }

                _context.UserAccount.Remove(userAccount);
                _context.SaveChanges();

                return RedirectToAction(nameof(UserAccount));
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
    }
}
