using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class ProductsController : Controller
    {
        //this is our data context, think of it as the gateway to the database.  it's how we store and retrieve information from the database.
        private Models.ProductEntities db = new Models.ProductEntities();

        // GET: Products
        public ActionResult Index()
        {
            //return all products
            return View(db.Products);
        }

        public ActionResult Details(int id)
        {
            //return just the one product the user wants to see
            var theProduct = db.Products.Find(id);
            if (theProduct == null)
            {
                return View("Error");
            }
            else
            {
                return View(theProduct);
            }
            
        }
    }
}