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
    public class ScoreHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScoreHistory
        public async Task<ActionResult> Index()
        {
            return View(await db.ScoreHistoryModels.ToListAsync());
        }

        // GET: ScoreHistory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreHistoryModel scoreHistoryModel = await db.ScoreHistoryModels.FindAsync(id);
            if (scoreHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(scoreHistoryModel);
        }

        // GET: ScoreHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScoreHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ScoreHistoryId,Year,ScoreOfYear")] ScoreHistoryModel scoreHistoryModel)
        {
            if (ModelState.IsValid)
            {
                db.ScoreHistoryModels.Add(scoreHistoryModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(scoreHistoryModel);
        }

        // GET: ScoreHistory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreHistoryModel scoreHistoryModel = await db.ScoreHistoryModels.FindAsync(id);
            if (scoreHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(scoreHistoryModel);
        }

        // POST: ScoreHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ScoreHistoryId,Year,ScoreOfYear")] ScoreHistoryModel scoreHistoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scoreHistoryModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scoreHistoryModel);
        }

        // GET: ScoreHistory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreHistoryModel scoreHistoryModel = await db.ScoreHistoryModels.FindAsync(id);
            if (scoreHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(scoreHistoryModel);
        }

        // POST: ScoreHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ScoreHistoryModel scoreHistoryModel = await db.ScoreHistoryModels.FindAsync(id);
            db.ScoreHistoryModels.Remove(scoreHistoryModel);
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
