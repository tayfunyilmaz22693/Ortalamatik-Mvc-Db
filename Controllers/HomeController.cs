using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ortalama.Models;
using Ortalama.Models.Entities;

namespace OrtalaMatik.Controllers;

public class HomeController : Controller
{
    MydbContext db = new MydbContext();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [Route("/")]

    public IActionResult Index()
    {
        var model = new Lesson()
        {
            allLessons = db.Lessons.OrderByDescending(x => x.Id).ToList(),
        };
        return View(model);
    }
    [Route("/add-lesson")]
    [ValidateAntiForgeryToken]
    public IActionResult AddLesson(Lesson lesson)
    {
        db.Lessons.Add(lesson);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    [Route("/delete-lesson/{id}")]
    public IActionResult DeleteLesson(int id)
    {
        var item = db.Lessons.SingleOrDefault(x => x.Id == id);
        db.Lessons.Remove(item!);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult UpdateLesson() {
        return RedirectToAction("Index");
    }
    [Route("/edit-Lesson/{id}")]
    public IActionResult UpdateLesson(Lesson lesson)
    {
        var item = db.Lessons.SingleOrDefault(x => x.Id == lesson.Id);
        item!.LessonName = lesson.LessonName;
        item.LessonNote = lesson.LessonNote;
        item.LessonCredit = lesson.LessonCredit;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
