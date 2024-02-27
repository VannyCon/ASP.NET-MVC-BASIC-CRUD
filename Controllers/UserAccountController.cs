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
            return View();
        }
        // CREATE
        [HttpPost]
        public IActionResult userCreate(UserAccount userAcc)
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
        // READ
        public IActionResult UserAccount()
        {
            var userAcc = _context.UserAccount.ToList();
            return View(userAcc);
        }
        // UPDATE
        public IActionResult Edit(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserAccount userAcc)
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

        //DELETE
        public IActionResult Delete(int id)
        {
            return PartialView("_DeleteConfirmation", id);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userAcc = _context.UserAccount.Find(id);
            if (userAcc == null)
            {
                return NotFound();
            }

            _context.UserAccount.Remove(userAcc);
            _context.SaveChanges();

            return RedirectToAction(nameof(UserAccount)); ;
        }
    }
}
