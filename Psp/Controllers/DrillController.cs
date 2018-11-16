using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Psp.Models;

namespace Psp.Controllers
{
    public class DrillController : Controller
    {
        CuttingToolsContext db = new CuttingToolsContext();
     
        [HttpGet]
        public ActionResult DrillForm()
        {
            welcomInscription();
            IEnumerable<Drill> drills = db.Drills;
            ViewBag.Drills = drills;
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult WatchDrill(int id)
        {
            welcomInscription();
            var Drill = db.Drills.Single(d => d.Id == id);
            return View(Drill);
        }


        [HttpGet]
        public ActionResult AddDrill()
        {
            welcomInscription();
            return View();
        }

        [HttpPost]
        public ActionResult AddDrill(Drill drill)
        {
            if (ModelState.IsValid)
            {
                db.Drills.Add(drill);
                db.SaveChanges();
                return RedirectToAction("DrillForm");
            }
            else
                return View();
        }


        [HttpGet]
        public ActionResult DeleteDrill(int? id)
        {
            welcomInscription();
            if (id == null)
            {
                return HttpNotFound();
            }

            Drill b = db.Drills.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            return View(b);
        }
        [HttpPost, ActionName("DeleteDrill")]

        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Drill b = db.Drills.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            db.Drills.Remove(b);
            db.SaveChanges();
            return RedirectToAction("DrillForm");
        }


        [HttpGet]
        public ActionResult EditDrill(int? id)
        {
            welcomInscription();
            if (id == null)
            {
                return HttpNotFound();
            }

            Drill drills = db.Drills.Find(id);
            if (drills == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = drills.Id;
            return View(drills);
        }

        [HttpPost]
        public ActionResult EditDrill(Drill drill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drill).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DrillForm");
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