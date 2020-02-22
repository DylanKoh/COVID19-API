using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COVID19_API;

namespace COVID19_API.Controllers
{
    public class ContactTracingsController : Controller
    {
        private COVID19Entities db = new COVID19Entities();

        public ContactTracingsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: ContactTracings
        [HttpPost]
        public ActionResult Index()
        {
            var contactTracings = db.ContactTracings;
            return new JsonResult { Data = contactTracings.ToList() };
        }

        // GET: ContactTracings/Details/5
        [HttpPost]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTracing contactTracing = db.ContactTracings.Find(id);
            if (contactTracing == null)
            {
                return HttpNotFound();
            }
            return View(contactTracing);
        }


        // POST: ContactTracings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FTE_ID,LocationID,FullName,Email,Contact,Temp,RegisterDateTime,ExitDateTime")] ContactTracing contactTracing)
        {
            if (ModelState.IsValid)
            {
                contactTracing.ID = db.ContactTracings.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault() + 1;
                db.ContactTracings.Add(contactTracing);
                db.SaveChanges();
                return Json("Records saved!");
            }

            return Json("Unable to save records!");
        }


        // POST: ContactTracings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,FTE_ID,LocationID,FullName,Email,Contact,Temp,RegisterDateTime,ExitDateTime")] ContactTracing contactTracing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactTracing).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Edit successful");
            }
            return Json("Edit unsuccessful");
        }

       

        // POST: ContactTracings/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            ContactTracing contactTracing = db.ContactTracings.Find(id);
            db.ContactTracings.Remove(contactTracing);
            db.SaveChanges();
            return Json("Delete successful");
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
