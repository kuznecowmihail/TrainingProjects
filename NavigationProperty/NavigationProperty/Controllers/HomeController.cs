using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NavigationProperty.Models;

namespace NavigationProperty.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> GetPlayers()
        {
            List<Player> players;

            using (FootballContext db = new FootballContext())
            {
                players = await db.Players.Include(t => t.Team).ToListAsync();
            }

            return View(players);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            using (FootballContext db = new FootballContext())
            {
                ViewBag.TeamNames = await Task.Run(() => db.Teams.ToList());
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Player player)
        {
            if(player == null)
            {
                return HttpNotFound();
            }

            using (FootballContext db = new FootballContext())
            {
                db.Entry(player).State = EntityState.Added;
                await db.SaveChangesAsync();
            }

            return RedirectToAction("GetPlayers");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            Player player;

            using (FootballContext db = new FootballContext())
            {
                var players = await db.Players.Include(t => t.Team).ToListAsync();
                player = players.Where(t => t.ID == id).FirstOrDefault();
                ViewBag.TeamNames = await Task.Run(() => db.Teams.ToList());
            }

            if (player != null)
            {

                return View(player);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string action, string teamID, Player player)
        {
            if(action == "Cancel")
            {
                return RedirectToAction("GetPlayers");
            }

            using (FootballContext db = new FootballContext())
            {
                player.TeamID = Convert.ToInt32(teamID);
                db.Entry(player).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return RedirectToAction("GetPlayers");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Player player;

            using (FootballContext db = new FootballContext())
            {
                player = await Task.Run(() => db.Players.Include(t => t.Team).Where(t => t.ID == id).FirstOrDefault());
            }

            if(player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string action, Player player)
        {
            if(action == "Cancel")
            {
                return RedirectToAction("GetPlayers");
            }

            using (FootballContext db = new FootballContext())
            {
                db.Entry(player).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }

            return RedirectToAction("GetPlayers");
        }

        public async Task<ActionResult> GetTeams()
        {
            List<Team> teams;

            using (FootballContext db = new FootballContext())
            {
                teams = await db.Teams.Include(t => t.Players).ToListAsync();
            }

            return View(teams);
        }

        public async Task<ActionResult> GetDetails(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            List<Team> teams;
            Team team;

            using (FootballContext db = new FootballContext())
            {
                teams = await db.Teams.Include(t => t.Players).ToListAsync();
                team = teams.Where(t => t.ID == id).FirstOrDefault();
            }

            if (team != null)
            {
                return View(team);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}