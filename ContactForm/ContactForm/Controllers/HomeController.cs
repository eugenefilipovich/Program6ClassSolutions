using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace ContactForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new Models.ContactForm());
        }

        [HttpPost]

        public ActionResult Contact(Models.ContactForm contactForm)
        {
            // add the form to the database
            try
            {
                contactForm.DtCreated = DateTime.Now;
                // doing smth
                // adding smth to the database
                // step 1: create the data context
                Models.ContactFormEntities db = new Models.ContactFormEntities();
                // step 2: Add the object to the table
                db.ContactForms.Add(contactForm);
                // step 3: save
                db.SaveChanges();
            }
            catch (Exception)
            {
                // if it blows up do this
                return View("Error");
            }
            // mail us a copy
            // host: mail.dustinkraft.com, port: 587, user: postmaster@dustinkraft.com, password: techIsFun1
            MailMessage mail = new MailMessage();
            // who it's from
            mail.From = new MailAddress("the_robots@seedpaths.com");

            // send it to
            mail.To.Add("eugenefilipovich1@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";

            // connecting to the actual email server
            SmtpClient SmtpServer = new SmtpClient("mail.dustinkraft.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");

            SmtpServer.Send(mail);
 
            // redirect the user to the thank you page
            return RedirectToAction("ThankYou", "Home");
        }
    }
}