using ClothingStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ClothingStoreApp.Controllers
{
    public class HomeController : Controller
    {
        ClothesAppDbContext db = new ClothesAppDbContext();
        public ActionResult Index(int page = 1)
        {
            //ViewBag.Clothes = db.Clothes;
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Clothes> clothesPerPage = db.Clothes.OrderBy(x=>x.ClothesId).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Clothes.Count() };
            IndexModels indexModels = new IndexModels { PageInfo = pageInfo, Clothes = clothesPerPage };
            return View(indexModels);
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

        //public ActionResult Delete(int id)
        //{
        //    var cloth = db.Clothes.Find(id);
        //    if (book != null)
        //    {
        //        db.Clothes.Remove(book);
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //ViewBag.Id = id;
            var cloth = db.Clothes.Find(id);
            if (cloth == null)
            {
                return HttpNotFound();
            }
            return View(cloth);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var c = db.Clothes.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            db.Clothes.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var clothes = db.Clothes.Find(id);
            if (clothes != null)
            {
                return View(clothes);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Clothes clothes)
        {
            db.Entry(clothes).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// Метод осущ. покупку предмета одежды
        /// </summary>
        /// <param name="purchase">сущ. покупки</param>
        /// <returns></returns>
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