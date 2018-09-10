using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj_Proje.Models
{
    public class MapModel
    {
        public long TC { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Bus_Selection { get; set; }
        public string Date { get; set; }
        public int? Status { get; set; }
        public List<MapModel> listOfDrivers;
        public List<string> error;
        public MapModel()
        {
            error = new List<string>();
        }

        public List<string> InsertTheDriver(long TC, string Name, string Surname, int Bus_Selection)
        {
            // Insert işlemi
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            Drivers driver = new Drivers();
            driver.TC = TC;
            driver.Name = Name;
            driver.Surname = Surname;
            driver.Bus_Selection = Bus_Selection;
            driver.Status = 1;
            DateTime now = DateTime.Now;
            driver.Date = now.ToString("dd-MM-yy HH:mm:ss");
            // firstOrDefault veya first (.First())
            // first : Bana obje dödürür
            // firstOrDefault : Bana obje dödürür
            // Eğer db de bu 2 değer varsa (TCCompare ve Bus_SelectionCompare)
            bool TCCompare = db.Drivers.Any(x => x.TC == TC && x.Status == 1 && x.Name == Name && x.Surname == Surname);
            error = new List<string>();

            if (!TCCompare)
            {
                db.Drivers.Add(driver);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.StackTrace.ToString();
                }
                error.Add("Sürücü sisteme başarıyla kaydedilmiştir");
            }
            else
            {   
                error.Add("Bu sürücü zaten sisteme kayıtlı\n");   
            }
            return error;
        }


        public void ShowDrivers()
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            listOfDrivers = new List<MapModel>();
            foreach (var drivers in db.Drivers.Where(x=> x.Status == 1))
            {
                listOfDrivers.Add(new MapModel()
                {
                    TC = drivers.TC,
                    Name = drivers.Name,
                    Surname = drivers.Surname,
                    Bus_Selection = drivers.Bus_Selection,
                    Date = drivers.Date,
                    Status = drivers.Status
                });
            }

        }

        // Formu doldurmak için
        public void UpdateDriver(long? TC)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            MapModel drivers = new MapModel();
            var getDrivers = db.Drivers.FirstOrDefault(d => d.TC == TC && d.Status == 1);

            if (getDrivers != null)
            {
                this.TC = getDrivers.TC;
                Name = getDrivers.Name;
                Surname = getDrivers.Surname;
                Bus_Selection = getDrivers.Bus_Selection;
            }
        }


        // Metodun aldığı parametreler db dekileri değiştirecek
        public List<string> UpdateDriver(long TC, string Name, string Surname, int Bus_Selection)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            error = new List<string>();
            var driverKontrol = db.Drivers.FirstOrDefault(d => d.TC == TC && d.Status == 1);
            var busKontrol = db.Drivers.Any(x => x.Bus_Selection == Bus_Selection && x.TC != TC && x.Status == 1);

            if (driverKontrol != null)
            {
                if (busKontrol) // Çünkü aynı otobüs numarası 2 sürücüye verilemez
                {
                    error.Add("Bu otobüs numarası kullanılıyor\n");
                }
                else
                {
                    driverKontrol.Name = Name;
                    driverKontrol.Surname = Surname;
                    driverKontrol.Bus_Selection = Bus_Selection;
                    DateTime now = DateTime.Now;
                    driverKontrol.Date = now.ToString("dd-MM-yy HH:mm:ss");
                    db.SaveChanges();
                    error.Add("Sürücü başarıyla güncellenmiştir");
                }
            }

            return error;
        }

      
    }
}