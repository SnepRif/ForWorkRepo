using FootballClubProj.Models;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;

namespace FootballClubProj.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();

        public ActionResult Index(int? team, string position)
        {
            IQueryable<Player> players = db.Players.Include(p => p.Team);
            if (team != null && team != 0)
            {
                players = players.Where(p => p.TeamId == team);
            }
            if (!String.IsNullOrEmpty(position) && !position.Equals("Все"))
            {
                players = players.Where(p => p.Position == position);
            }

            List<Team> teams = db.Teams.ToList();
            //устанавливаем начальный элемент который позволяет выбрать всех
            teams.Insert(0, new Team { Name = "Все", Id = 0 });

            PlayerListViewModel plvm = new PlayerListViewModel
            {
                Players = players.ToList(),
                Teams = new SelectList(teams, "Id", "Name"),
                Positions = new SelectList(new List<string>()
                {
                    "Все",
                    "Нападающий",
                    "Полузащитник",
                    "Защитник",
                    "Вратарь"

                })
            };
            return View(plvm);


        }

        [HttpGet]
        public ActionResult Create()
        {
            // Список команд для передачи в представление
            SelectList teams = new SelectList(db.Teams, "Id", "Name");

            ViewBag.Teams = teams;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Player player)
        {
            db.Players.Add(player);
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
            var player = db.Players.Find(id);
            if (player != null)
            {
                var teams = new SelectList(db.Teams, "Id", "Name", player.TeamId);
                ViewBag.Teams = teams;
                return View(player);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var player = db.Players.Find(id);
            if (player != null)
            {
                db.Players.Remove(player);
                db.SaveChanges();
            }
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