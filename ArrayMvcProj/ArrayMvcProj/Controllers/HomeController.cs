using ArrayMvcProj.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArrayMvcProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Edit()
        //{
        //    List<Book> books = new List<Book>();
        //    books.Add(new Book { Name = "Ведьмак", Author = "Сапковский", Price = 300 });
        //    books.Add(new Book { Name = "Гарри Поттер", Author = "Роулинг", Price = 450 });
        //    books.Add(new Book { Name = "С#", Author = "Рихтер", Price = 800 });

        //    return View(books);

        //}
        //[HttpPost]
        //public string Edit(List<Book> books)
        //{
        //    return books.Count.ToString();
        //}

        public ActionResult GetAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAuthor(Author author)
        {
            return View();
        }

        public ActionResult Array()
        {
            return View();
        }

        [HttpPost]
        public string Array(List<string> names)
        {
            string str = "";
            for (int i = 0; i < names.Count; i++)
            {
                str += names[i] + "; ";
            }
            return str;
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