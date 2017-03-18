using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Riggen.Models;

namespace Riggen.Controllers
{
    public class TournamentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tournaments
        public async Task<ActionResult> Index()
        {
            return View(await db.TournamentModels.ToListAsync());
        }

        // GET: Tournaments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentModel tournamentModel = await db.TournamentModels.FindAsync(id);
            if (tournamentModel == null)
            {
                return HttpNotFound();
            }
            return View(tournamentModel);
        }

        // GET: Tournaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TournamentId,TournamentDate,TournamentName,TournamentType")] TournamentModel tournamentModel)
        {
            if (ModelState.IsValid)
            {
                db.TournamentModels.Add(tournamentModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tournamentModel);
        }

        // GET: Tournaments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentModel tournamentModel = await db.TournamentModels.FindAsync(id);
            if (tournamentModel == null)
            {
                return HttpNotFound();
            }
            return View(tournamentModel);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TournamentId,TournamentDate,TournamentName,TournamentType")] TournamentModel tournamentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournamentModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tournamentModel);
        }

        // GET: Tournaments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentModel tournamentModel = await db.TournamentModels.FindAsync(id);
            if (tournamentModel == null)
            {
                return HttpNotFound();
            }
            return View(tournamentModel);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TournamentModel tournamentModel = await db.TournamentModels.FindAsync(id);
            db.TournamentModels.Remove(tournamentModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
