using Staj_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_Proje.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult OtobusKayit()
        {
            BusRouteModel otobusNumarasi = new BusRouteModel();
            otobusNumarasi.busNumbersComboBoxDoldur = new List<int>();
            otobusNumarasi.busNumbersComboBoxDoldur = otobusNumarasi.ShowBusNumbers();
            var tuple = new Tuple<BusRouteModel, BusModel>(otobusNumarasi, new BusModel());
            return View(tuple);
        }

        [HttpPost]
        public ActionResult OtobusKayit(string Plaka_No, int Bus_Selection)
        {
            BusModel bus = new BusModel();
            bus.error = new List<string>();
            bus.error = bus.InsertTheBus(Plaka_No, Bus_Selection);
            BusRouteModel otobusNumarasi = new BusRouteModel();
            otobusNumarasi.busNumbersComboBoxDoldur = new List<int>();
            otobusNumarasi.busNumbersComboBoxDoldur = otobusNumarasi.ShowBusNumbers();
            var tuple = new Tuple<BusRouteModel, BusModel>(otobusNumarasi, bus);
            return View(tuple);
        }

        public ActionResult OtobusGoruntule()
        {
            BusModel bus = new BusModel();
            bus.listOfBusses = new List<BusModel>();
            bus.ShowBusStops();
            return View(bus);
        }

        public JsonResult OtobusSil(int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            Busses bus = new Busses();
            bus = db.Busses.Where(b => b.Id == Id).First();
            if (bus != null)
            {
                bus.Status = 0;
                db.SaveChanges();
            }

            return Json(new { islem = 1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OtobusGuncelle(int Id)
        {
            BusRouteModel otobusNumarasi = new BusRouteModel();
            otobusNumarasi.busNumbersComboBoxDoldur = new List<int>();
            otobusNumarasi.busNumbersComboBoxDoldur = otobusNumarasi.ShowBusNumbers();
            BusModel bus = new BusModel();
            bus.UpdateTheBus(Id);
            var tuple = new Tuple<BusRouteModel, BusModel>(otobusNumarasi, bus);
            return View(tuple);
        }

        [HttpPost]
        public ActionResult OtobusGuncelle(int Id, string Plaka_No, int Bus_Selection)
        {
            BusModel bus = new BusModel();
            bus.error = new List<string>();
            bus.error = bus.UpdateTheBus(Id, Plaka_No, Bus_Selection);
            BusRouteModel otobusNumarasi = new BusRouteModel();
            otobusNumarasi.busNumbersComboBoxDoldur = new List<int>();
            otobusNumarasi.busNumbersComboBoxDoldur = otobusNumarasi.ShowBusNumbers();
            var tuple = new Tuple<BusRouteModel, BusModel>(otobusNumarasi, bus);
            return View(tuple);
        }

    }
}