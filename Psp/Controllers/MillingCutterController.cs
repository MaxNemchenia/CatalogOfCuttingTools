using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Psp.Models;

namespace Psp.Controllers
{
    public class MillingCutterController : Controller
    {
        CuttingToolsContext db = new CuttingToolsContext();


        [HttpGet]
        public ActionResult MillingForm()
        {
            welcomInscription();
            IEnumerable<MillingCutter> millingCutters = db.MillingCutters;
            ViewBag.MillingCutters = millingCutters;
            return View();
        }
               

        [Authorize]
        [HttpGet]
        public ActionResult WatchMilling(int id)
        {
            welcomInscription();
            var Milling = db.MillingCutters.Single(d => d.Id == id);
            return View(Milling);
        }


        [HttpGet]
        public ActionResult AddMilling()
        {
            welcomInscription();
            return View();
        }

        [HttpPost]
        public ActionResult AddMilling(MillingCutter milling)
        {
            if (ModelState.IsValid)
            {
                db.MillingCutters.Add(milling);
                db.SaveChanges();
                return RedirectToAction("MillingForm");
            }
            else
                return View();
        }


        [HttpGet]
        public ActionResult DeleteMilling(int? id)
        {
            welcomInscription();
            if (id == null)
            {
                return HttpNotFound();
            }

            MillingCutter b = db.MillingCutters.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            return View(b);
        }

        [HttpPost, ActionName("DeleteMilling")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            MillingCutter b = db.MillingCutters.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            db.MillingCutters.Remove(b);
            db.SaveChanges();
            return RedirectToAction("MillingForm");
        }


        [HttpGet]
        public ActionResult EditMilling(int? id)
        {
            welcomInscription();
            if (id == null)
            {
                return HttpNotFound();
            }

            MillingCutter milling = db.MillingCutters.Find(id);
            if (milling == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = milling.Id;
            return View(milling);
        }

        [HttpPost]
        public ActionResult EditMilling(MillingCutter milling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(milling).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MillingForm");
            }
            else
                return View();
        }


        [HttpPost]
        public ActionResult InstrumentSearch(string name)
        {
            welcomInscription();

            var allInstruments = db.Drills.Where(a => a.Name.Contains(name)).ToList();
            var allInstruments2 = db.Cutters.Where(a => a.Name.Contains(name)).ToList();
            var allInstruments3 = db.MillingCutters.Where(a => a.Name.Contains(name)).ToList();

            ViewBag.Name = name;
            ViewBag.Cutter = allInstruments2.ToList(); ;
            ViewBag.Milling = allInstruments3.ToList(); ;
            return PartialView(allInstruments);
        }

        public void welcomInscription()
        {
            ViewBag.user = "Guest";
            if ((User.IsInRole("Admin")) || (User.IsInRole("user")))
                ViewBag.user = User.Identity.Name;

            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
        }
    }
}