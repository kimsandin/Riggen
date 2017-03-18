using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Riggen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Riggen.Controllers
{
    public class UsersController : Controller
    {
        
        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";
                var x = new RoleController(); bool isAdmin = x.isAdminUser();

                if (isAdmin)
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }
    }
}