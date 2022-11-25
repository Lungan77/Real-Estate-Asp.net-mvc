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
    [Authorize(Roles = "Client")]
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payments
        public ActionResult Index()
        {
            var log = User.Identity.GetUserId();

            var client = (from d in db.clients
                          where d.User_Id == log
                          select d.Id).SingleOrDefault();

            var payments = db.Payments.Include(p => p.Client).Include(p => p.Property);

            payments = from d in payments
                       where d.ClientId == client
                       select d;

            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        public ActionResult Payment_done(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        [Authorize(Roles = "Client")]
        public ActionResult Create(int? id)
        {
            double price = (from n in db.Properties
                         where n.Id == id
                         select n.Balance).SingleOrDefault();

            ViewBag.Price = price;

            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Client")]
        public ActionResult Create(int? id, [Bind(Include = "Id,Price,Date,PropertyId,ClientId")] Payment payment)
        {

            double price = (from n in db.Properties
                            where n.Id == id
                            select n.Balance).SingleOrDefault();

            ViewBag.Price = price;

            if (ModelState.IsValid)
            {
                
                string userId = User.Identity.GetUserId();

                int Client_Id = (from c in db.clients
                                 where c.User_Id == userId
                                 select c.Id).SingleOrDefault();

                string Client_Name = (from c in db.clients
                                 where c.User_Id == userId
                                 select c.Name).SingleOrDefault();

                string Client_Email = (from c in db.clients
                                      where c.User_Id == userId
                                      select c.Email).SingleOrDefault();

                

                var Check_Buyer = (from c in db.Buyer
                               where c.PropertyId == (int)id
                               select c.AgentUserId).SingleOrDefault();

                string Agent_UserId = (from c in db.Properties
                                       where c.Id == id
                                       select c.AgentId).SingleOrDefault();

                if (Check_Buyer == null)
                {
                    var buyer = new Buyer
                    {
                        Name = Client_Name,
                        Email = Client_Email,
                        PropertyId = (int)id,
                        AgentUserId = Agent_UserId
                    };

                    db.Buyer.Add(buyer);
                    db.SaveChanges();
                }

                var PropName = (from d in db.Properties
                            where d.Id == id
                            select d.PropertyName).SingleOrDefault();

                var PropType = (from d in db.Properties
                                where d.Id == id
                                select d.PropertyType).SingleOrDefault();

                var Province = (from d in db.Properties
                                where d.Id == id
                                select d.Province).SingleOrDefault();

                var CityorSuburb = (from d in db.Properties
                                where d.Id == id
                                    select d.CityorSuburb).SingleOrDefault();

                var Postal = (from d in db.Properties
                                    where d.Id == id
                              select d.PostalCode).SingleOrDefault();

                var Address = (from d in db.Properties
                                    where d.Id == id
                               select d.Address).SingleOrDefault();

                var AgentName = (from d in db.Properties
                                    where d.Id == id
                                 select d.AgentName).SingleOrDefault();

                var AgentId = (from d in db.Properties
                                    where d.Id == id
                               select d.AgentId).SingleOrDefault();

                var Price = (from d in db.Properties
                                    where d.Id == id
                             select d.Price).SingleOrDefault();

                var Agent_share = (from d in db.Properties
                                    where d.Id == id
                                   select d.Agent_share).SingleOrDefault();

                var PropertyInf = (from d in db.Properties
                                    where d.Id == id
                                   select d.PropertyInf).SingleOrDefault();

                var Agent_phone = (from d in db.Properties
                                    where d.Id == id
                                   select d.AgentPhoneNumber).SingleOrDefault();

                var Balance = (from d in db.Properties
                                    where d.Id == id
                               select d.Balance).SingleOrDefault();

                Balance -= payment.Price;

                var Seller = (from d in db.Properties
                                    where d.Id == id
                              select d.SellerId).SingleOrDefault();

                var Image = (from d in db.Properties
                                    where d.Id == id
                             select d.ImageURL).SingleOrDefault();

                var Image1 = (from d in db.Properties
                                    where d.Id == id
                              select d.ImageURL1).SingleOrDefault();

                var Image2 = (from d in db.Properties
                                    where d.Id == id
                              select d.ImageURL2).SingleOrDefault();

                var Image3 = (from d in db.Properties
                                    where d.Id == id
                              select d.ImageURL3).SingleOrDefault();

                var propery = new Property
                {
                    Id = (int)id,
                    PropertyName = PropName,
                    PropertyType = PropType,
                    Province = Province,
                    CityorSuburb = CityorSuburb,
                    PostalCode = Postal,
                    Address = Address,
                    AgentName = AgentName,
                    AgentId = AgentId,
                    Price = Price,
                    Agent_share = Agent_share,
                    PropertyInf = PropertyInf,
                    AgentPhoneNumber = Agent_phone,
                    Sold = true,
                    ClientId = Client_Id,
                    Balance = Balance,
                    SellerId = Seller,
                    ImageURL = Image,
                    ImageURL1 = Image1,
                    ImageURL2 = Image2,
                    ImageURL3 = Image3
                };

                db.Entry(propery).State = EntityState.Modified;
                db.SaveChanges();

                var email = (from d in db.clients
                             where d.User_Id == userId
                             select d.Email).SingleOrDefault();

                var mail = new Email
                {
                    To = email,
                    Subject = "Payment Successful",
                    Body = "Payment of " + "R" + " " + payment.Price.ToString() + " Done"
                };

                mail.SendMail();

                payment.Date = DateTime.Now;
                payment.ClientId = Client_Id;
                payment.PropertyId = (int)id;
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Payment_done/" + payment.Id);
            }

            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name", payment.ClientId);
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyName", payment.PropertyId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,PropertyId,ClientId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name", payment.ClientId);
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyName", payment.PropertyId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
