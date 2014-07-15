using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class ListItemController : Controller
    {
        private ShoppingListContext db = new ShoppingListContext();

        //
        // GET: /ListItem/

        public ActionResult Index()
        {
            var listitems = db.ListItems.Include(l => l.ShoppingList);
            return View(listitems.ToList());
        }

        //
        // GET: /ListItem/Details/5

        public ActionResult Details(int id = 0)
        {
            ListItem listitem = db.ListItems.Find(id);
            if (listitem == null)
            {
                return HttpNotFound();
            }
            return View(listitem);
        }

        //
        // GET: /ListItem/Create

        public ActionResult Create(int id)
        {
            return View(new ListItem {List_Id = id});
        }

        //
        // POST: /ListItem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListItem listitem)
        {
            if (ModelState.IsValid)
            {
                db.ListItems.Add(listitem);
                db.SaveChanges();
                return RedirectToAction("Details","List",new{id=listitem.List_Id});
            }

            return View(listitem);
        }

        //
        // GET: /ListItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ListItem listitem = db.ListItems.Find(id);
            if (listitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.List_Id = new SelectList(db.Lists, "Id", "Name", listitem.List_Id);
            return View(listitem);
        }

        //
        // POST: /ListItem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListItem listitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "List", new { id = listitem.List_Id });
            }
            ViewBag.List_Id = new SelectList(db.Lists, "Id", "Name", listitem.List_Id);
            return View(listitem);
        }

        //
        // GET: /ListItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ListItem listitem = db.ListItems.Find(id);
            if (listitem == null)
            {
                return HttpNotFound();
            }
            return View(listitem);
        }

        //
        // POST: /ListItem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListItem listitem = db.ListItems.Find(id);
            db.ListItems.Remove(listitem);
            db.SaveChanges();
            return RedirectToAction("Details", "List", new { id = listitem.List_Id });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}