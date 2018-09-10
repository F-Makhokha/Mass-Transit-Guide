using Staj_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_Proje.Controllers
{
    public class BusRouteController : Controller
    {
        // GET: BusRoute
        public ActionResult HatEkle()
        {
            return View(new BusRouteModel());
        }

        [HttpPost]
        public ActionResult HatEkle(int Bus_Selection)
        {
            BusRouteModel hat = new BusRouteModel();
            hat.error = new List<string>();
            hat.error = hat.InsertTheBusNumber(Bus_Selection);
            return View(hat);
        }

        public ActionResult HatGoster()
        {
            BusRouteModel hat = new BusRouteModel();
            hat.listOfBusNumbers = new List<BusRouteModel>();
            hat.ShowBusNumbers();
            return View(hat);
        }

        public JsonResult OtobusNumarasiSil(int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            BusNumbers bus = new BusNumbers();
            bus = db.BusNumbers.Where(b => b.Id == Id).First();
            if (bus != null)
            {
                bus.Status = 0;
                db.SaveChanges();
            }

            return Json(new { islem = 1 }, JsonRequestBehavior.AllowGet);
        }
    }
}