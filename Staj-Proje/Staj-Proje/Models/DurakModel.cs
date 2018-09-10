using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// DB tablosunun adı BusStops

namespace Staj_Proje.Models
{
    public class DurakModel
    {
        public int Id { get; set; }
        public string Enlem { get; set; }
        public string Boylam { get; set; }
        public string Durak_Adi { get; set; }
        public string Date { get; set; }
        public int? Status { get; set; } // nullable status = null; olabilir
        public List<DurakModel> listOfBusStops;
        public List<string> error;
        public DurakModel()
        {
            error = new List<string>();
            listOfBusStops = new List<DurakModel>();
        }

        // InsertTheBusStop
        public List<string> InsertTheBusStop(string Durak_Adi, string Enlem, string Boylam)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            BusStops duraklar = new BusStops();
            duraklar.Enlem = Enlem.Substring(0,8);
            duraklar.Boylam = Boylam.Substring(0,8);
            duraklar.Durak_Adi = Durak_Adi;
            duraklar.Status = 1;
            DateTime now = DateTime.Now;
            duraklar.Date = now.ToString("dd-MM-yy HH:mm:ss");

            bool durakTablodaVarMi = db.BusStops.Any(x => x.Durak_Adi == Durak_Adi);
            bool enlemVeBoylamTablodaVarMi = db.BusStops.Any(x => x.Enlem == duraklar.Enlem && x.Boylam == duraklar.Boylam);
            error = new List<string>();
            if (!durakTablodaVarMi && !enlemVeBoylamTablodaVarMi)
            {
                db.BusStops.Add(duraklar);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.StackTrace.ToString();
                }
                error.Add("Durak sisteme başarıyla kaydedilmiştir");
            }
            else
            {
                if (durakTablodaVarMi)
                {
                    error.Add("Bu durak adı kullanılıyor\n");
                }
                if (enlemVeBoylamTablodaVarMi)
                {
                    error.Add("Bu konumda zaten bir durak var\n");
                }
            }

            return error;
        }

        // ShowBusStops
        public List<DurakModel> ShowBusStops()
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            listOfBusStops = new List<DurakModel>();
            foreach(var busStops in db.BusStops.Where(b => b.Status == 1))
            {
                listOfBusStops.Add(new DurakModel()
                {
                    Durak_Adi = busStops.Durak_Adi,
                    Enlem = busStops.Enlem,
                    Boylam = busStops.Boylam,
                    Date = busStops.Date,
                    Id = busStops.Id
                });
            }

            return listOfBusStops;
        }

        // Formu doldurmak için (UpdateTheBusStop)
        public void UpdateTheBusStop(int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            //DurakModel busStops = new DurakModel();
            var getBusStops = db.BusStops.FirstOrDefault(b => b.Id == Id && b.Status == 1);

            if (getBusStops != null)
            {
                Durak_Adi = getBusStops.Durak_Adi;
                Enlem = getBusStops.Enlem;
                Boylam = getBusStops.Boylam;
            }
        }

        // UpdateTheBusStop
        public List<string> UpdateTheBusStop(string Durak_Adi, string Enlem, string Boylam, int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            error = new List<string>();
            // Bu durak adı db de yoksa ve statusü 1 ise
            var durakAdiKontrol = db.BusStops.FirstOrDefault(b => b.Durak_Adi != Durak_Adi && b.Status == 1 && b.Id == Id);

            if (durakAdiKontrol != null)
            {
                durakAdiKontrol.Durak_Adi = Durak_Adi;
                durakAdiKontrol.Enlem = Enlem.Substring(0, 8);
                durakAdiKontrol.Boylam = Boylam.Substring(0, 8);
                DateTime now = DateTime.Now;
                durakAdiKontrol.Date = now.ToString("dd-MM-yy HH:mm:ss");
                db.SaveChanges();
                error.Add("Durak başarıyla güncellenmiştir");
            }

            else
            {
                error.Add("Bu durak adı zaten kullanılıyor");
            }

            return error;
        }
    }
}