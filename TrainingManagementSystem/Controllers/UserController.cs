using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using TrainingManagementSystem.Context;
using TrainingManagementSystem.Models;

namespace TrainingManagementSystem.Controllers
{
    public class UserController : Controller
    {
        TrainingDbContext _context;
        public UserController(TrainingDbContext trainingDbContext) {
        _context = trainingDbContext;
        }
        public IActionResult Index()
        {

            return View(_context.Users.Where(x => (int)x.Role != 0).ToList()) ;
        }

        public IActionResult Create() {
            ViewData["ManagerId"] = new SelectList(_context.Users.Where(x => (int)x.Role == 1), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid) {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Edit(int? id)
        {
            ViewData["managerid"] = new SelectList(_context.Users.Where(x => (int)x.Role == 1), "Id", "Name", null);
            User user = _context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Details(int? id)
        {
            User user = _context.Users.Find(id);
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
            {
                user.IsActive = false;
                _context.SaveChanges();
            }
            return View("Index");
        }
    }
}
