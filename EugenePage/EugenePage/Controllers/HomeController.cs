using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace EugenePage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Name, string Email, string Message)
        {
            var message = new MailMessage("eugeneportfoliorobot@seedpaths.com", "eugenefilipovich1@gmail.com");
            var client = new SmtpClient("mail.dustinkraft.com", 587)
            {
                Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1")
            };
            message.Body = Name + " tried to contact you. Their email is " + Email + ". The message they left was: \"" + Message + "\"";
            message.Subject = "Someone wants to contact you!";
            client.Send(message);

            ViewBag.Message = "Your information has been submitted successfully! I will contact you soon! Want to add something? No problem!";
            return View();
        }
    }
}