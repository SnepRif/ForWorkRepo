using ClothingStoreApp.Models;
using System;
using System.Web.Mvc;

namespace ClothingStoreApp.Controllers
{
    public class HomeController : Controller
    {
        ClothesAppDbContext db = new ClothesAppDbContext();
        public ActionResult Index()
        {
            var clothes = db.Clothes;
            ViewBag.Clothes = clothes;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clothes clothes)
        {
            db.Clothes.Add(clothes);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();

            return $"Спасибо за покупку ! {purchase.Person}";
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