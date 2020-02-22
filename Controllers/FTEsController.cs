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
    public class FTEsController : Controller
    {
        private COVID19Entities db = new COVID19Entities();
        public FTEsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // GET: FTEs
        [HttpPost]
        public ActionResult Index()
        {
            return new JsonResult { Data = db.FTEs.ToList() };
        }

        // GET: FTEs/Details/5
        [HttpPost]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FTE fTE = db.FTEs.Find(id);
            if (fTE == null)
            {
                return Json("User does not exist in database!");
            }
            return Json(fTE);
        }



        // POST: FTEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,NRIC,UserID,FullName,Email,Contact")] FTE fTE)
        {
            if (ModelState.IsValid)
            {
                db.FTEs.Add(fTE);
                db.SaveChanges();
                return Json("User created successful");
            }

            return Json("Unable to create account");
        }


        // POST: FTEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,NRIC,UserID,FullName,Email,Contact")] FTE fTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fTE).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Edit successful");
            }
            return Json("Unable to edit user!");
        }



        // POST: FTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            FTE fTE = db.FTEs.Find(id);
            db.FTEs.Remove(fTE);
            db.SaveChanges();
            return Json("Delete successful");
        }

        [HttpPost]
        public ActionResult Login(string userID, string password)
        {
            var user = db.FTEs.Where(x => x.UserID == userID && x.NRIC == password).Select(x => x).FirstOrDefault();
            if (user == null)
            {
                return Json("Unable to find user from your UserID and password!");
            }
            else
            {
                return Json(user);
            }

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
