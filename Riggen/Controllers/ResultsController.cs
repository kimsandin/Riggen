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
    public class ResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Results
        public async Task<ActionResult> Index()
        {
            return View(await db.ResultModels.ToListAsync());
        }

        // GET: Results/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultModel resultModel = await db.ResultModels.FindAsync(id);
            if (resultModel == null)
            {
                return HttpNotFound();
            }
            return View(resultModel);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ResultId,Date,NewScore,ResultHistory,TotalScore")] ResultModel resultModel)
        {
            if (ModelState.IsValid)
            {
                db.ResultModels.Add(resultModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(resultModel);
        }

        // GET: Results/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultModel resultModel = await db.ResultModels.FindAsync(id);
            if (resultModel == null)
            {
                return HttpNotFound();
            }
            return View(resultModel);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ResultId,Date,NewScore,ResultHistory,TotalScore")] ResultModel resultModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(resultModel);
        }

        // GET: Results/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultModel resultModel = await db.ResultModels.FindAsync(id);
            if (resultModel == null)
            {
                return HttpNotFound();
            }
            return View(resultModel);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ResultModel resultModel = await db.ResultModels.FindAsync(id);
            db.ResultModels.Remove(resultModel);
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
