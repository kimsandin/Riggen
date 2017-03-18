using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Riggen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Riggen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = new ApplicationUser();
            if (user != null)
            {
                var x = new RoleController(); bool isAdmin = x.isAdminUser();
                if (isAdmin)
                {
                    return View();
                }
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Välkommen till Riggen!";

            return View();
        }

        [HttpPost]
        public ViewResult About(ContactRequest contactRequest)
        {
            if (ModelState.IsValid)
            {
                var customerName = contactRequest.Name;
                var customerEmail = contactRequest.Email;
                var customerRequest = contactRequest.SupportRequest;
                var supportEmail = "kontakt@cimoco.se";
                //TODO: Email question to support
                try
                {
                    WebMail.SmtpServer = "smtp01.binero.se";
                    WebMail.SmtpPort = 587;
                    WebMail.SmtpUseDefaultCredentials = false;
                    WebMail.EnableSsl = true;
                    WebMail.UserName = "kontakt@riggenpoker.se";
                    WebMail.Password = "123456";
                    WebMail.From = supportEmail;
                    WebMail.Send(to: supportEmail, subject: "Help request from - " + customerName,
                        body: "Support request from: " + customerName + ", \nPhonenumber: " + ", \nEmail: " + customerEmail + ", \nQuestion: " + customerRequest


                    );
                    return View("Thanks", contactRequest);
                }
                catch (Exception)//(NullReferenceException ex)
                {
                    //ViewBag.ErrorMessage = ex.Message;
                    return View("SendEmailError");
                }
            }
            else
            {
                // there is a validation error
                return View();
            }

        }
    }
}