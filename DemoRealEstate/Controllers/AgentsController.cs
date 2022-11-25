using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoRealEstate.Models;
using Microsoft.AspNet.Identity;

namespace DemoRealEstate.Controllers
{
    [Authorize(Roles = "Agent")]
    public class AgentsController : Controller
    {
        private ApplicationDbContext _Context;

        public AgentsController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        // GET: Agents
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgentProperty(string searchString, string province, string cityorsuburb)
        {

            var cityOrSuburb = new List<string>();

            var cities = from d in _Context.Properties
                         orderby d.CityorSuburb
                         select d.CityorSuburb;

            cityOrSuburb.AddRange(cities.Distinct());
            ViewBag.cityorsuburb = new SelectList(cityOrSuburb);

            var provinces = new List<string>();

            var provinceslist = from d in _Context.Properties
                                orderby d.Province
                                select d.Province;

            provinces.AddRange(provinceslist.Distinct());
            ViewBag.province = new SelectList(provinces);

            var loggedIn = User.Identity.GetUserId();

            var properties = _Context.Properties.Include(p => p.Seller);

            var AgentProperty = (from db in properties
                                where db.AgentId == loggedIn
                                select db);

            var Properties = AgentProperty;

            if (!String.IsNullOrEmpty(searchString))
            {
                Properties = Properties.Where(s => s.PropertyName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(province))
            {
                Properties = Properties.Where(x => x.Province == province);
            }

            if (!string.IsNullOrEmpty(cityorsuburb))
            {
                Properties = Properties.Where(x => x.CityorSuburb == cityorsuburb);
            }

            return View(Properties.ToList());
        }

        public ActionResult Edit(int? id)
        {

            var loggedIn = User.Identity.GetUserId();

            var Agent = _Context.Agents;

            var AgentId = (from db in Agent
                           where db.UserId == loggedIn
                           select db).SingleOrDefault();

            id = AgentId.Id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = _Context.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Email,PhoneNumber,UserId,Agent_share")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                agent.UserId = User.Identity.GetUserId();
                _Context.Entry(agent).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        public ActionResult Details(int? id)
        {

            var loggedIn = User.Identity.GetUserId();

            var Agent = _Context.Agents;

            var AgentId = (from db in Agent
                           where db.UserId == loggedIn
                           select db).SingleOrDefault();

            id = AgentId.Id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = _Context.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        public ActionResult MyClients()
        {
            return View();
        }
    }
}