using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj_Proje.Models
{
    public class BusRouteModel
    {
        public int Id { get; set; }
        public int Bus_Selection { get; set; }
        public int Status { get; set; }
        public string Date { get; set; }
        public List<BusRouteModel> listOfBusNumbers;
        public List<int> busNumbersComboBoxDoldur; // combobox'ı dolduracak
        public List<string> error;
        public BusRouteModel()
        {
            error = new List<string>();
            busNumbersComboBoxDoldur = new List<int>();
        }

        //InsertTheBusNumber
        public List<string> InsertTheBusNumber(int Bus_Selection)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            BusNumbers busNumbers = new BusNumbers();
            busNumbers.Bus_Selection = Bus_Selection;
            busNumbers.Status = 1;
            DateTime now = DateTime.Now;
            busNumbers.Date = now.ToString("dd-MM-yy HH:mm:ss");

            // plaka ve tablo aynı anda kontrol edilecek
            bool check = db.BusNumbers.Any(b => b.Bus_Selection != Bus_Selection);
            bool numaraTablodaVarMi = db.BusNumbers.Any(b => b.Bus_Selection == Bus_Selection && b.Status == 1);
            error = new List<string>();
            if (!numaraTablodaVarMi || check)
            {
                db.BusNumbers.Add(busNumbers);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.StackTrace.ToString();
                }
                error.Add("Otobüs numarası sisteme başarıyla kaydedilmiştir");
            }
            else
            {
                error.Add("Bu numara zaten kullanılıyor\n");
            }
            return error;
        }

        //ShowBusNumbers
        public List<int> ShowBusNumbers()
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            listOfBusNumbers = new List<BusRouteModel>();
            busNumbersComboBoxDoldur = new List<int>();
            foreach (var busses in db.BusNumbers.Where(b => b.Status == 1))
            {
                listOfBusNumbers.Add(new BusRouteModel()
                {
                    Id = busses.Id,
                    Bus_Selection = busses.Bus_Selection,
                    Date = busses.Date
                });
            }

            for (var i = 0; i < listOfBusNumbers.Count; i++ )
            {
                busNumbersComboBoxDoldur.Add(listOfBusNumbers.ElementAt(i).Bus_Selection);
            }

            return busNumbersComboBoxDoldur;
        }
    }
}