using Staj_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_Proje.Controllers
{
    public class DurakController : Controller
    {
        // GET: Bus
        public ActionResult DurakKayit()
        {
            return View(new DurakModel());
        }

        [HttpPost]
        public ActionResult DurakKayit(string Durak_Adi, string Enlem, string Boylam)
        {
            DurakModel durak = new DurakModel();
            durak.error = new List<string>();
            durak.error = durak.InsertTheBusStop(Durak_Adi, Enlem, Boylam);
            return View(durak);
        }

        // Form Collection Yapısı
        /*public void DurakKayit(FormCollection form)
        {
            string Durak_Adi = Request.Form["Durak_Adi"];
            string Enlem = Request.Form["Enlem"];
            string Boylam = Request.Form["Boylam"];
        }*/

        public ActionResult DurakGoruntule()
        {
            DurakModel durak = new DurakModel();
            durak.listOfBusStops = new List<DurakModel>();
            durak.ShowBusStops();
            return View(durak);
        }

        public JsonResult DurakSil(int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            BusStops durak = new BusStops();
            durak = db.BusStops.Where(d => d.Id == Id).First();
            if (durak != null)
            {
                durak.Status = 0;
                db.SaveChanges();
            }

            return Json(new { islem = 1 }, JsonRequestBehavior.AllowGet);
        }

        // Google mapsteki var olan haritaları göstermek için var
        // Güzergah id sinden o durakları bulmak lazım sonra siralama
        // Burada GüzergahDurak tablosundaki Siralamada getirlmeli bu duraklara ait
        [HttpPost]
        public JsonResult DuraklariHaritadaGoster()
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            DurakModel durak = new DurakModel();
            durak.listOfBusStops = new List<DurakModel>();
            //var durakSira = db.GuzergahDurak.Select(g => g.Siralama).Where();
            foreach (var busStops in db.BusStops.Where(b => b.Status == 1))
            {
                durak.listOfBusStops.Add(new DurakModel()
                {
                    Durak_Adi = busStops.Durak_Adi,
                    Enlem = busStops.Enlem,
                    Boylam = busStops.Boylam,
                    Id = busStops.Id,
                    Status = 1,
                    Date = busStops.Date
                });
            }

            return Json(durak.listOfBusStops, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DurakGuncelle(int Id)
        {
            DurakModel durak = new DurakModel();
            durak.UpdateTheBusStop(Id);
            return View(durak);
        }

        [HttpPost]
        public ActionResult DurakGuncelle(string Durak_Adi, string Enlem, string Boylam, int Id)
        {
            DurakModel busStops = new DurakModel();
            busStops.error = new List<string>();
            busStops.error = busStops.UpdateTheBusStop(Durak_Adi, Enlem, Boylam, Id);
            return View(busStops);
        }
    }
}