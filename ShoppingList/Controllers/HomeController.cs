using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class HomeController : Controller
    {
        private ShoppingListContext _db=new ShoppingListContext();
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var lists = _db.Lists.OrderByDescending(t => t.CreationDate).Take(5).ToList();
            return View(lists);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
