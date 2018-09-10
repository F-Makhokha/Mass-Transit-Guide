using Staj_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_Proje.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BusStop()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult BusRoute()
        {
            return View();
        }

        public ActionResult BusOperations()
        {
            return View();
        }

        // Sürücü Kayıt Sayfası
        public ActionResult DriverOperations()
        {
            BusRouteModel busModel = new BusRouteModel();
            busModel.busNumbersComboBoxDoldur = new List<int>();
            busModel.busNumbersComboBoxDoldur = busModel.ShowBusNumbers();
            var tuple = new Tuple<BusRouteModel, MapModel>(busModel, new MapModel());
            return View(tuple);
        }

        // Sürücü Kayıt Sayfası
        [HttpPost]
        public ActionResult DriverOperations(long TC, string Name, string Surname, int Bus_Selection)
        {
            MapModel mapModel = new MapModel();
            mapModel.error = new List<string>();
            mapModel.error = mapModel.InsertTheDriver(TC, Name, Surname, Bus_Selection);
            //ViewBag.mesaj = mesaj; List olduğu için ViewBag kullanamadım
            BusRouteModel otobusNumarasi = new BusRouteModel();
            otobusNumarasi.busNumbersComboBoxDoldur = new List<int>();
            otobusNumarasi.busNumbersComboBoxDoldur = otobusNumarasi.ShowBusNumbers();
            var tuple = new Tuple<BusRouteModel, MapModel>(otobusNumarasi, mapModel);
            return View(tuple);
        }

        public ActionResult ShowDrivers()
        {
            MapModel drivers = new MapModel();
            drivers.listOfDrivers = new List<MapModel>();
            drivers.ShowDrivers();

            return View(drivers);
        }

        public JsonResult ShowDriversDelete(long? tc)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            Drivers drivers = new Drivers();
            drivers = db.Drivers.Where(d => d.TC == tc).First();
            if (drivers!=null)
            {
                //db.Drivers.Remove(drivers);
                drivers.Status = 0;
                db.SaveChanges();
            }
            return Json(new { islem = 1 }, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult UpdateDrivers(long? TC)
        {
            BusRouteModel otobusNumarasi = new BusRouteModel();
            otobusNumarasi.busNumbersComboBoxDoldur = new List<int>();
            otobusNumarasi.busNumbersComboBoxDoldur = otobusNumarasi.ShowBusNumbers();
            MapModel drivers = new MapModel();
            drivers.UpdateDriver(TC);
            var tuple = new Tuple<BusRouteModel, MapModel>(otobusNumarasi, drivers);
            return View(tuple);
        }

        [HttpPost]
        public ActionResult UpdateDrivers(long TC, string Name, string Surname, int Bus_Selection)
        {
            MapModel drivers = new MapModel();
            drivers.error = new List<string>();
            drivers.error = drivers.UpdateDriver(TC, Name, Surname, Bus_Selection);
            BusRouteModel otobusNumarasi = new BusRouteModel();
            otobusNumarasi.busNumbersComboBoxDoldur = new List<int>();
            otobusNumarasi.busNumbersComboBoxDoldur = otobusNumarasi.ShowBusNumbers();
            var tuple = new Tuple<BusRouteModel, MapModel>(otobusNumarasi, drivers);
            return View(tuple);
        }
    }
}