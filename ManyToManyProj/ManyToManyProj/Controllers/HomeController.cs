using ManyToManyProj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManyToManyProj.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = db.Courses.ToList();
            return View(student);

        }

        [HttpPost]
        public ActionResult Edit(Student student, int[] selectedCourses)
        {
            var newStudent = db.Students.Find(student.Id);
            newStudent.Name = student.Name;
            newStudent.Surname = student.Surname;

            newStudent.Courses.Clear();
            if (selectedCourses != null)
            {
                foreach (var c in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    newStudent.Courses.Add(c);
                }
            }
            db.Entry(newStudent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Courses = db.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student, int[] selectedCourses)
        {
            if (selectedCourses != null)
            {
                foreach (var c in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    student.Courses.Add(c);
                }
            }
            db.Students.Add(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}