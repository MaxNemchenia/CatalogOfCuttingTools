using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Psp.Models;
using Psp.DAL;
using Psp.Controllers;



namespace Psp.Controllers
{
    public class HomeController : Controller
    {
        CuttingToolsContext db = new CuttingToolsContext();


        public ViewResult Index()
        {
            welcomInscription();
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