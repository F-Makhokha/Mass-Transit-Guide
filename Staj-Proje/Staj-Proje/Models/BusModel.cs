using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj_Proje.Models
{
    public class BusModel
    {
        public int Id { get; set; }
        public string Plaka_No { get; set; }
        public int Bus_Selection { get; set; }
        public int Status { get; set; }
        public string Date { get; set; }
        public List<BusModel> listOfBusses;
        public List<string> error;
        public BusModel()
        {
            error = new List<string>();
        }

        //InsertTheBus
        public List<string> InsertTheBus(string Plaka_No, int Bus_Selection)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            Busses busses = new Busses();
            busses.Plaka_No = Plaka_No;
            busses.Bus_Selection = Bus_Selection;
            busses.Status = 1;
            DateTime now = DateTime.Now;
            busses.Date = now.ToString("dd-MM-yy HH:mm:ss");

            // plaka ve tablo aynı anda kontrol edilecek
            bool plakaTablodaVarMi = db.Busses.Any(b => b.Plaka_No == Plaka_No && b.Bus_Selection == Bus_Selection);
            // gösterilende sadece statusu 1 olan tek bir plaka olmalı show da 2 plakayı görmemeliyiz
            bool plakaStatus = db.Busses.Any(b => b.Plaka_No == Plaka_No && b.Status == 1);
            error = new List<string>();
            if (!plakaTablodaVarMi && !plakaStatus)
            {
                db.Busses.Add(busses);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.StackTrace.ToString();
                }
                error.Add("Otobüs sisteme başarıyla kaydedilmiştir");
            }
            else
            {
                    error.Add("Bu plaka zaten kullanılıyor\n");
                
            }
            return error;
        }

        //ShowBusses
        public void ShowBusStops()
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            listOfBusses = new List<BusModel>();
            foreach (var busses in db.Busses.Where(b => b.Status == 1))
            {
                listOfBusses.Add(new BusModel()
                {
                    Id = busses.Id,
                    Plaka_No = busses.Plaka_No,
                    Bus_Selection = busses.Bus_Selection,
                    Date = busses.Date
                });
            }

        }

        // Formu Doldurmak İçin (UpdateTheBus)
        public void UpdateTheBus(int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            var getBusses = db.Busses.FirstOrDefault(b => b.Id == Id && b.Status == 1);

            if (getBusses != null)
            {
                Plaka_No = getBusses.Plaka_No;
                Bus_Selection = getBusses.Bus_Selection;
            }
        }

        //UpdateTheBus
        public List<string> UpdateTheBus(int Id, string Plaka_No, int Bus_Selection)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            error = new List<string>();
            var plakaKontrol = db.Busses.FirstOrDefault(b => b.Plaka_No != Plaka_No && b.Status == 1 && b.Id == Id);

            if (plakaKontrol != null)
            {
                plakaKontrol.Plaka_No = Plaka_No;
                plakaKontrol.Bus_Selection = Bus_Selection;
                DateTime now = DateTime.Now;
                plakaKontrol.Date = now.ToString("dd-MM-yy HH:mm:ss");
                db.SaveChanges();
                error.Add("Otobüs başarıyla güncellenmiştir");
            }
            else
            {
                error.Add("Bu plaka kullanılıyor");
            }

            return error;
        }
    }
}