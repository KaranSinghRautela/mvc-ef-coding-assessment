using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingManagementSystem.Context;
using TrainingManagementSystem.Models;

namespace TrainingManagementSystem.Controllers
{
    public class BatchController : Controller
    {
        TrainingDbContext _context;
        public BatchController(TrainingDbContext trainingDbContext) { 
        _context = trainingDbContext;
        }
        public IActionResult Index()
        {
            var list = from batch in _context.Batches
                       join course in _context.Courses
                       on batch.CourseId
                       equals course.CourseId
                       select new BatchViewModel
                       {
                           CourseName = course.CourseName,
                           BatchName = batch.BatchName,
                           Trainer = batch.Trainer,
                           StartDate = batch.StartDate,
                       };


            return View(list.ToList());
        }

        public IActionResult Create() {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Batch batch) {

                _context.Batches.Add(batch);
                _context.SaveChanges();
                return RedirectToAction("Index");

        }
    }

    public class BatchViewModel
    {
        [Key]
        public string BatchId { get; set; }
        public string BatchName { get; set; }
        public string CourseName { get; set; }
        public string Trainer { get; set; }
        public DateTime StartDate { get; set; }
    }
}
