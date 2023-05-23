using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystem.Context;
using TrainingManagementSystem.Models;

namespace TrainingManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        TrainingDbContext _context;
        public CourseController(TrainingDbContext trainingDbContext) {
            _context = trainingDbContext;
        }
        public IActionResult Index()
        {
            return View(_context.Courses.ToList());
        }

        public IActionResult Details(int? id) {
            Course course = _context.Courses.Find(id);
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            Course course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid) { 
            _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            Course course = _context.Courses.Find(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
