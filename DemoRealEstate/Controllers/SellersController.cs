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
    public class SellersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sellers
        public ActionResult Index(string searchString)
        {
            var sellers = from e in db.Seller
                          select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                sellers = sellers.Where(s => s.Name.Contains(searchString));
            }

            return View(sellers.ToList());
        }

        [Authorize(Roles = "Agent")]
        public ActionResult AgentSellers(string searchString)
        {

            var logged = User.Identity.GetUserId();

            var seller = from d in db.Seller
                         where d.AgentUserId == logged
                         select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                seller = seller.Where(s => s.Name.Contains(searchString));
            }

            return View(seller.ToList());
        }
        // GET: Sellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Seller.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        [Authorize(Roles = "Agent")]
        // GET: Sellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Agent")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,AgentUserId")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                seller.AgentUserId = User.Identity.GetUserId();
                db.Seller.Add(seller);
                db.SaveChanges();
                return RedirectToAction("Create", "Properties");
            }

            return View(seller);
        }

        // GET: Sellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Seller.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = db.Seller.Find(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seller seller = db.Seller.Find(id);
            db.Seller.Remove(seller);
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
