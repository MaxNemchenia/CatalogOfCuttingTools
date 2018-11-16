using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Psp.Models;

namespace Psp.Controllers
{
    public class CutterController : Controller
    {
        CuttingToolsContext db = new CuttingToolsContext();


        [HttpGet]
        public ActionResult CutterForm()
        {
            welcomInscription();
            IEnumerable<Cutter> cutters = db.Cutters;
            ViewBag.Cutters = cutters;
            return View();
        }


        [Authorize]
        [HttpGet]
        public ActionResult WatchCutter(int id)
        {
            welcomInscription();
            var Cutters = db.Cutters.Single(d => d.Id == id);
            return View(Cutters);
        }


        [HttpGet]
        public ActionResult AddCutter()
        {
            welcomInscription();
            return View();
        }

        [HttpPost]
        public ActionResult AddCutter(Cutter cutter)
        {
            if (ModelState.IsValid)
            {
                db.Cutters.Add(cutter);
                db.SaveChanges();
                return RedirectToAction("CutterForm");
            }
            else
                return View();
        }


        [HttpGet]
        public ActionResult DeleteCutter(int? id)
        {
            welcomInscription();
            if (id == null)
            {
                return HttpNotFound();
            }

            Cutter b = db.Cutters.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            return View(b);
        }

        [HttpPost, ActionName("DeleteCutter")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cutter b = db.Cutters.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            db.Cutters.Remove(b);
            db.SaveChanges();
            return RedirectToAction("CutterForm");
        }


        [HttpGet]
        public ActionResult EditCutter(int? id)
        {
            welcomInscription();
            if (id == null)
            {
                return HttpNotFound();
            }

            Cutter cutters = db.Cutters.Find(id);
            if (cutters == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = cutters.Id;
            return View(cutters);
        }

        [HttpPost]
        public ActionResult EditCutter(Cutter cutter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cutter).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CutterForm");
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