using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Riggen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Riggen.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private ApplicationDbContext context = new ApplicationDbContext();

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminRoles()
        {
            ViewBag.userName = context.Users.Select(o => new SelectListItem { Value = o.UserName, Text = o.UserName });
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ViewBag.Admins = context.Users.ToList().Where(u => userManager.IsInRole(u.Id, "Admin")).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(string userName, string officeName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var user = context.Users.Where(u => u.UserName == userName).SingleOrDefault();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (!userManager.IsInRole(user.Id, "Admin"))
                //Adding a role to user.
                {
                    userManager.AddToRole(user.Id, "Admin");
                    context.SaveChanges();
                }

            }
            return RedirectToAction("AdminRoles");
        }


        public ActionResult DeleteAdmin(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }
            else {
                var user = context.Users.Where(u => u.Id == id).SingleOrDefault();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    userManager.RemoveFromRole(user.Id, "Admin");
                }
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Guest()
        {
            return View(await db.GuestUserModels.ToListAsync());
        }

        // GET: Guests/Details
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestUserModel Guest = await db.GuestUserModels.FindAsync(id);
            if (Guest == null)
            {
                return HttpNotFound();
            }
            return View(Guest);
        }

        public ActionResult CreateGuest()
        {
            return View();
        }

        

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateGuest([Bind(Include = "GuestUserId,GuestUserName")] GuestUserModel guests)
        {
            if (ModelState.IsValid)
            { 
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);
                ApplicationUser currentAdmin = userManager.FindById(User.Identity.GetUserId());

                if (!db.GuestUserModels.Any(g => g.GuestUserName == guests.GuestUserName))
                {
                    //await this.UserManager.AddToRoleAsync(guests.GuestUserId, );
                    //guests.AddToRole(guests.GuestUserId, "Guest");
                    TempData["Message"] = "Gästspelaren har lagts till!";
                    db.GuestUserModels.Add(guests);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Guest", "Admin");
                }    
                            
                else {
                    TempData["Message"] = "Det finns redan en gästspelare med samma namn";
                    return RedirectToAction("CreateGuest", "Admin");
                }
            }
            TempData["Message"] = "Något gick fel. försök igen!";
            return RedirectToAction("CreateGuest", "Admin");

        }


        public ActionResult DeleteGuest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                GuestUserModel guest = db.GuestUserModels.Find(id);
                if (guest == null)
                {
                    return HttpNotFound();
                }
                return View(guest);
            }
        }


        // POST: Guest/Delete/5
        [HttpPost, ActionName("DeleteGuest")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GuestUserModel guest = await db.GuestUserModels.FindAsync(id);
            db.GuestUserModels.Remove(guest);
            await db.SaveChangesAsync();
            return RedirectToAction("Guest", "Admin");
        }
            
        

    }
}