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
    public class RequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Requests
        [Authorize(Roles = "Agent, Client")]
        public ActionResult Index(string Agents, string Client)
        {
            var log = User.Identity.GetUserId();

            var requests = db.Requests.Include(r => r.Agent);

            var agent_Id = (from d in db.Agents
                                where d.UserId == log
                                select d.Id).SingleOrDefault();

            var Agent = (from e in db.Agents
                         where e.UserId == log
                         select e.UserId).SingleOrDefault();
            
            if (Agent == log)
            {
                var Req = from c in requests
                      where c.AgentId == agent_Id
                      select c;
                requests = Req;
            }
            else
            {
                var Req = from c in requests
                      where c.User_id == log
                      select c;
                requests = Req;
            }

            var agents = new List<string>();

            var agents_name = from e in requests
                              orderby e.Agent.Name
                              select e.Agent.Name;

            agents.AddRange(agents_name.Distinct());
            ViewBag.Agents = new SelectList(agents);

            var Client_List = new List<string>();

            var Clients_List = from d in requests
                               orderby d.Name
                               select d.Name;

            Client_List.AddRange(Clients_List.Distinct());
            ViewBag.Client = new SelectList(Client_List);

            if (!String.IsNullOrEmpty(Agents))
            {
                requests = requests.Where(s => s.Agent.Name == Agents);
            }

            if (!String.IsNullOrEmpty(Client))
            {
                requests = requests.Where(d => d.Name == Client);
            }

            return View(requests.ToList());
        }
      
        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        [Authorize(Roles = "Client")]
        public ActionResult Create()
        {
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Client")]
        public ActionResult Create([Bind(Include = "Id,Name,Message,From,To,User_id,AgentId")] Request request)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();

                if (request.AgentId == 0)
                {

                    var id = (from t in db.Agents
                             where t.UserId == user
                             select t.Id).SingleOrDefault();

                    request.AgentId = id;
                }
                if(request.User_id == null)
                {
                    request.User_id = User.Identity.GetUserId();                                                   
                }
                var agentId = request.AgentId;
                var agent = (from t in db.Agents
                             where t.Id == agentId
                             select t.UserId).SingleOrDefault();

                request.To = agent;
                request.From = User.Identity.GetUserId();
                string Name = (from c in db.clients
                               where c.User_Id == user
                               select c.Name).SingleOrDefault();
                request.Name = Name;

                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name", request.AgentId);
            return View(request);
        }

        [Authorize(Roles = "Agent")]
        public ActionResult Reply()
        {
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agent")]
        public ActionResult Reply([Bind(Include = "Id,Name,Message,From,To,User_id,AgentId")] Request request, string userId, int Id)
        {
            

            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();

                if (request.AgentId == 0)
                {

                    var id = (from t in db.Agents
                              where t.UserId == user
                              select t.Id).SingleOrDefault();

                    request.AgentId = id;
                }

                if (request.Name == null)
                {
                    int Agent_Id = (from c in db.Agents
                                   where c.UserId == user
                                   select c.Id).SingleOrDefault();

                    string name = (from f in db.Requests
                                   where f.AgentId == Agent_Id && f.Id == Id
                                   select f.Name).SingleOrDefault();

                    request.Name = name;
                }
                request.To = userId;
                request.From = User.Identity.GetUserId();
                request.User_id = userId;
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name", request.AgentId);
            return View(request);
        }
        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name", request.AgentId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Message,From,To,User_id,AgentId")] Request request)
        {
            if (ModelState.IsValid)
            {

                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name", request.AgentId);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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
