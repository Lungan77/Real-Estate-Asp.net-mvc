using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoRealEstate.Models;
using Microsoft.AspNet.Identity;

namespace DemoRealEstate.Controllers
{
    [Authorize(Roles = "Agent, Admin")]
    public class BuyersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Buyers
        public ActionResult Index(string searchString)
        {
            var buyer = db.Buyer.Include(b => b.Property);

            if (!String.IsNullOrEmpty(searchString))
            {
                buyer = buyer.Where(s => s.Name.Contains(searchString));
            }

            return View(buyer.ToList());
        }

        // GET: Buyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyer buyer = db.Buyer.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        // GET: Buyers/Create
        [Authorize(Roles = "Agent")]
        public ActionResult Create()
        {
            var logged = User.Identity.GetUserId();

            var properties = from d in db.Properties
                             where d.AgentId == logged
                             select d;

            properties = from e in properties
                         where e.Sold == true
                         select e;


            ViewBag.PropertyId = new SelectList(properties, "Id", "PropertyName");
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Agent")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,PropertyId,AgentUserId")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                buyer.AgentUserId = User.Identity.GetUserId();
                db.Buyer.Add(buyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var logged = User.Identity.GetUserId();

            var properties = from d in db.Properties
                         where d.AgentId == logged
                         select d;

            ViewBag.PropertyId = new SelectList(properties, "Id", "PropertyName", buyer.PropertyId);
            return View(buyer);
        }

        // GET: Buyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyer buyer = db.Buyer.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyName", buyer.PropertyId);
            return View(buyer);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,PropertyId")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyName", buyer.PropertyId);
            return View(buyer);
        }

        // GET: Buyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyer buyer = db.Buyer.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buyer buyer = db.Buyer.Find(id);
            db.Buyer.Remove(buyer);
            db.SaveChanges();
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
