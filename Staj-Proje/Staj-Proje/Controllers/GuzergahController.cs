using Staj_Proje.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace Staj_Proje.Controllers
{
    [DataContract]
    public class Idler
    {
        [DataMember]
        public int id { get; set; }
        public List<int> idArray { get; set; }

        public Idler()
        {
            idArray = new List<int>();
        }
    }

    public class GuzergahController : Controller
    {
        // GET: Guzergah
       
        public ActionResult GuzergahEkle()
        { 
            return View(new GuzergahModel());
        }

        [HttpPost]
        public ActionResult GuzergahEkle(string Guzergah_Adi, int Gidis_Donus, int[] abc)
        {
            GuzergahModel guzergah = new GuzergahModel
            {
                error = new List<string>()
            };
            guzergah.error = guzergah.GuzergahKaydet(Guzergah_Adi, Gidis_Donus, abc);
            return View(guzergah);
        }

        public ActionResult GuzergahGoster()
        {
            GuzergahModel guzergah = new GuzergahModel();
            guzergah.guzergahListesi = new List<Guzergah>();
            guzergah.GuzergahGoruntule();
            return View(guzergah);
        }

        public JsonResult GuzergahSil(int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            Guzergah guzergah = new Guzergah();
            guzergah = db.Guzergah.Where(g => g.Guzergah_Id == Id).First();
            if (guzergah != null)
            {
                guzergah.Status = 0;
                db.SaveChanges();
            }
            return Json(new { islem = 1 }, JsonRequestBehavior.AllowGet);
        }

        // Tuple lazım çünkü durakları anca GuzergahDuraktan Güzergah_Id si ile alınabilir
        public ActionResult GuzergahGuncelle(int Id)
        {
            GuzergahModel guzergah = new GuzergahModel();
            guzergah.guzergahListesi = new List<Guzergah>();
            guzergah.GuzergahGuncelle(Id);
            return View(guzergah);
        }

        [HttpPost]
        public ActionResult GuzergahGuncelle(int Id, string Guzergah_Adi, int Gidis_Donus, int? []abc)
        {
            GuzergahModel guzergah = new GuzergahModel();
            guzergah.error = new List<string>();
            guzergah.guzergahListesi = new List<Guzergah>();
            guzergah.error = guzergah.GuzergahGuncelle(Id, Guzergah_Adi, Gidis_Donus, abc);
            return View(guzergah);
        }

        [HttpPost]
        public JsonResult GuzergahDurakSil(int durakId, int guzergahId)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            GuzergahDurak gdurak = new GuzergahDurak();
            gdurak = db.GuzergahDurak.Where(g => g.Id == durakId && g.Guzergah_Id == guzergahId).First();
            if (gdurak != null)
            {
                db.GuzergahDurak.Remove(gdurak);
                db.SaveChanges();
            }
            return Json(new { islem = 1 }, JsonRequestBehavior.AllowGet);
        }

        // Bir tane dropdown olacak, üstte yine bir harita bu haritada duraklar seçili, dropdowndan guzergahi
        // sectigim an sayfa yenilenip o guzergahlar arası çizgi çekip yolu çizecek
        // Durak listesi getirilecek harita için
        public ActionResult GuzergahYoluGoster()
        {
            GuzergahModel guzergah = new GuzergahModel();
            guzergah.guzergahComboBox = new List<string>();
            guzergah.guzergahListesi = new List<Guzergah>();
            guzergah.error = new List<string>();
            guzergah.guzergahComboBox = guzergah.GuzergahGoruntule();
            return View(guzergah);
        }

        // Enumerable şeklinde alınacak duraklariCiz ve model de dolduğunu da düşünmüyorum orayada dikkat et
        // Ve actionlar da böyle olmayacak gibi biraz düşün üzerine
        public JsonResult GuzergahYoluCiz(string Guzergah_Adi)
        {
            GuzergahModel guzergah = new GuzergahModel();
            object a = guzergah.GuzergahYoluCiz(Guzergah_Adi);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuzergahYoluDuzenle()
        {
            GuzergahModel guzergah = new GuzergahModel();
            guzergah.guzergahComboBox = new List<string>();
            guzergah.guzergahListesi = new List<Guzergah>();
            guzergah.error = new List<string>();
            guzergah.guzergahComboBox = guzergah.GuzergahGoruntule();
            return View(guzergah);
        }

        // Değişen durakların sıralarını kaydeder
        public JsonResult GuzergahYolundakiDuraklariGuncelle(string array, int Guzergah_Id)
        {
            Idler idler = new Idler();
            JArray varray = JArray.Parse(array);
            idler = JsonConvert.DeserializeObject<Idler>(array);
            idler.idArray.Add(idler.id);
            GuzergahModel guzergah = new GuzergahModel();
            return Json("fs",JsonRequestBehavior.AllowGet);
        }
       
    }
}