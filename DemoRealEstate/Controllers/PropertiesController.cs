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
   [Authorize]
    public class PropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Properties
        public ActionResult Index(string searchString, string province, string cityorsuburb)
        {

            var cityOrSuburb = new List<string>();

            var cities = from d in db.Properties
                                orderby d.CityorSuburb
                                select d.CityorSuburb;

            cityOrSuburb.AddRange(cities.Distinct());
            ViewBag.cityorsuburb = new SelectList(cityOrSuburb);

            var provinces = new List<string>();

            var provinceslist = from d in db.Properties
                           orderby d.Province
                           select d.Province;

            provinces.AddRange(provinceslist.Distinct());
            ViewBag.province = new SelectList(provinces);

            var property = db.Properties.Include(p => p.Seller);
            property = from e in property
                       where e.Sold == false
                       select e;

            var properties = property;

            if (!String.IsNullOrEmpty(searchString))
            {
                properties = properties.Where(s => s.PropertyName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(province))
            {
                properties = properties.Where(x => x.Province == province);
            }

            if (!string.IsNullOrEmpty(cityorsuburb))
            {
                properties = properties.Where(x => x.CityorSuburb == cityorsuburb);
            }


            return View(properties.ToList());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            var logged = User.Identity.GetUserId();

            int ClientId = (from f in db.Properties
                            where f.Id == id
                            select f.ClientId).SingleOrDefault();
                             
            string User_Id = User.Identity.GetUserId();

            int Client = (from d in db.clients
                          where d.User_Id == logged
                          select d.Id).SingleOrDefault();

            ViewBag.ClientId = ClientId;

            ViewBag.Client = Client;

            if (property == null)
            {
                return HttpNotFound();
            }


            return View(property);
        }

        // GET: Properties/Create
        [Authorize(Roles = "Agent, Admin")]
        public ActionResult Create()
        {

            string[] propertyTypes = new string[5];
            propertyTypes[0] = "APARTMENT";
            propertyTypes[1] = "HOUSE";
            propertyTypes[2] = "LAND";
            propertyTypes[3] = "INDUSTRIAL";
            propertyTypes[4] = "TOWNHOUSE";

            ViewBag.PropertyType = new SelectList(propertyTypes);

            string[] provinces = new string[9];
            provinces[0] = "KWAZULU NATAL";
            provinces[1] = "EASTERN CAPE";
            provinces[2] = "WESTERN CAPE";
            provinces[3] = "NORTHERN CAPE";
            provinces[4] = "GAUTENG";
            provinces[5] = "NORTH WEST";
            provinces[6] = "FREE STATE";
            provinces[7] = "MPUMALANGA";
            provinces[8] = "LIMPOPO";

            ViewBag.Province = new SelectList(provinces);

            var logged = User.Identity.GetUserId();

            var seller = from d in db.Seller
                         where d.AgentUserId == logged
                         select d;

            ViewBag.SellerId = new SelectList(seller, "Id", "Name");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agent, Admin")]
        public ActionResult Create([Bind(Include = "Id,PropertyName,PropertyType,Province,CityorSuburb,postalCode,Address,AgentName,AgentId,Price,PropertyInf,Sold,SellerId,ImageURL,ImageURL1,ImageURL2,ImageURL3,AgentPhoneNumber,Agent_share,Balance")] Property property)
        {
            var logged = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {

                int Fee = Convert.ToInt32(property.Price);
                
                var agentName = (from d in db.Agents
                                where d.UserId == logged
                                select d.Name).SingleOrDefault();

                var agent_share = (from d in db.Agents
                                 where d.UserId == logged
                                 select d.Agent_share).SingleOrDefault();

                var agentPhone = (from d in db.Agents
                                 where d.UserId == logged
                                 select d.PhoneNumber).SingleOrDefault();

                int price = ((agent_share / 100) * Fee);
                property.Agent_share = price;
                property.Balance = (int)property.Price;
                property.AgentPhoneNumber = agentPhone;
                property.AgentName = agentName;
                property.AgentId = User.Identity.GetUserId();
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("AgentProperty", "Agents");
            }


            var seller = from d in db.Seller
                         where d.AgentUserId == logged
                         select d;

            ViewBag.SellerId = new SelectList(seller, "Id", "Name", property.SellerId);

            string[] propertyTypes = new string[5];
            propertyTypes[0] = "APARTMENT";
            propertyTypes[1] = "HOUSE";
            propertyTypes[2] = "LAND";
            propertyTypes[3] = "INDUSTRIAL";
            propertyTypes[4] = "TOWNHOUSE";

            ViewBag.PropertyType = new SelectList(propertyTypes);

            string[] provinces = new string[9];
            provinces[0] = "KWAZULU NATAL";
            provinces[1] = "EASTERN CAPE";
            provinces[2] = "WESTERN CAPE";
            provinces[3] = "NORTHERN CAPE";
            provinces[4] = "GAUTENG";
            provinces[5] = "NORTH WEST";
            provinces[6] = "FREE STATE";
            provinces[7] = "MPUMALANGA";
            provinces[8] = "LIMPOPO";

            ViewBag.Province = new SelectList(provinces);

            return View(property);
        }
       
        // GET: Properties/Edit/5
        [Authorize(Roles = "Agent, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name", property.ClientId);
            ViewBag.SellerId = new SelectList(db.Seller, "Id", "Name", property.SellerId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agent, Admin")]
        public ActionResult Edit([Bind(Include = "Id,PropertyName,PropertyType,Province,CityorSuburb,postalCode,Address,AgentName,AgentId,Price,PropertyInf,Sold,SellerId,ImageURL,ImageURL1,ImageURL2,ImageURL3,AgentPhoneNumber,Agent_share,ClientId,Balance")] Property property)
        {
            if (ModelState.IsValid)
            {
                var logged = User.Identity.GetUserId();

                var agent_share = (from d in db.Agents
                                   where d.UserId == logged
                                   select d.Agent_share).SingleOrDefault();

                property.Balance = (int)property.Price;
                double share = agent_share;
                double Share = share / 100;
                var price = property.Price;
                double fee = Share * price;
                int Fee = Convert.ToInt32(fee);

                property.Agent_share = Fee;
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AgentProperty", "Agents" );
            }

            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name", property.ClientId);
            ViewBag.SellerId = new SelectList(db.Seller, "Id", "Name", property.SellerId);
            return View(property);
        }

        // GET: Properties/Delete/5
        [Authorize(Roles = "Agent, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agent, Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("AgentProperty", "Agents");
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
