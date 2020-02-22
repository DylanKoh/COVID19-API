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
    public class LocationsController : Controller
    {
        private COVID19Entities db = new COVID19Entities();
        public LocationsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        // GET: Locations
        [HttpPost]
        public ActionResult Index()
        {
            return new JsonResult { Data = db.Locations.ToList() };
        }

        // GET: Locations/Details/5
        [HttpPost]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return Json(location);
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
