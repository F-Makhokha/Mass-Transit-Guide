using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Staj_Proje.Models
{
    public class GuzergahModel
    {
        [Key]
        public int Guzergah_Id { get; set; }
        public string Guzergah_Adi { get; set; }
        public int Gidis_Donus { get; set; }
        public int Status { get; set; }
        public string Date { get; set; }
        public List<string> error;
        public List<Guzergah> guzergahListesi;
        public List<string> guzergahComboBox;
        public string durakId;
        public string durakAdi;
        public object duraklariCiz; // Bunun için enumaratör tanımlanacak
        public GuzergahModel()
        {
            error = new List<string>();
            guzergahListesi = new List<Guzergah>();
            guzergahComboBox = new List<string>();           
        }

        public List<string> GuzergahKaydet(string Guzergah_Adi, int Gidis_Donus, int[] Array1)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            Guzergah guzergah = new Guzergah();
            guzergah.Guzergah_Adi = Guzergah_Adi;
            guzergah.Gidis_Donus = Gidis_Donus;
            guzergah.Status = 1;
            DateTime now = DateTime.Now;
            guzergah.Date = now.ToString("dd-MM-yy HH:mm:ss");

            // Foreign Keyleri yerleştirdik
            for (var i = 0; i < Array1.Count(); i++)
            {
                guzergah.GuzergahDurak.Add(new GuzergahDurak()
                {
                    Guzergah_Id = Guzergah_Id,
                    Id = Array1[i], //Arrayden gelen valuelar eklenecek
                    Siralama = i + 1
                });
            }
            error = new List<string>();
            // False gelmeli
            var guzergahAdiTablodaVarMi = db.Guzergah.Any(x => x.Guzergah_Adi == Guzergah_Adi && x.Status == 1);

            if (!guzergahAdiTablodaVarMi)
            {
                db.Guzergah.Add(guzergah);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.StackTrace.ToString();
                }
                error.Add("Guzergah başarıyla kaydedilmiştir");
            }
            else
            {
                error.Add("Guzergah adi zaten kullanılıyor");
            }

            return error;
        }

        public List<string> GuzergahGoruntule()
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            guzergahListesi = new List<Guzergah>();
            guzergahComboBox = new List<string>();
            foreach (var guzergah in db.Guzergah.Where(g => g.Status == 1))
            {
                guzergahListesi.Add(new Guzergah()
                {
                    Guzergah_Id = guzergah.Guzergah_Id,
                    Guzergah_Adi = guzergah.Guzergah_Adi,
                    Gidis_Donus = guzergah.Gidis_Donus,
                    Date = guzergah.Date
                });
            }

            for (var i=0; i<guzergahListesi.Count(); i++)
            {
                guzergahComboBox.Add(guzergahListesi.ElementAt(i).Guzergah_Adi);
            }

            return guzergahComboBox;
        }

        // Formu dolu getirmek için
        public void GuzergahGuncelle(int Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            var getGuzergahs = db.Guzergah.FirstOrDefault(g => g.Guzergah_Id == Id && g.Status == 1);

            // Bütün bu id lere sahip olanları bir arraye attık
            durakId = string.Join(",", db.GuzergahDurak.Where(g => g.Guzergah_Id == Id).Select(x => x.Id).ToList());
            // id leri aldık ama bu durak id lerine ait olan durak adlarına ulaşmam lazım, o durak adlarıda BusStopsa
            // specific durak idsi lazım
            durakAdi = string.Join(",", db.GuzergahDurak.Where(g => g.Guzergah_Id == Id).Select(x => x.BusStops.Durak_Adi).ToList());

            if (getGuzergahs != null)
            {
                Guzergah_Adi = getGuzergahs.Guzergah_Adi;
                Gidis_Donus = getGuzergahs.Gidis_Donus;
                Guzergah_Id = getGuzergahs.Guzergah_Id;
            }
        }

        public List<string> GuzergahGuncelle(int Id, string Guzergah_Adi, int Gidis_Donus, int?[] abc)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            // Guzergah Tablosunun güncellenmesi
            Guzergah guzergah = new Guzergah();
            guzergah.Guzergah_Adi = Guzergah_Adi;
            guzergah.Gidis_Donus = Gidis_Donus;
            guzergah.Status = 1;
            DateTime now = DateTime.Now;
            guzergah.Date = now.ToString("dd-MM-yy HH:mm:ss");
            // GüzergahDurak Tablosunun Gücellenmesi
            // Foreach lazım, yeni duraklar şeklinde, tek değişecek şey güzergah id olacak ama ya kullanıcı yeni durak eklerse?

            // Db deki durak id lerini getir abc arrayiyle kıyasla
            var guzergahDuraklari = db.GuzergahDurak.Where(x => x.Guzergah_Id == Id).Select(x => x.Id).ToArray();
            var dbDeOlmayanDuraklar = abc.Except(guzergahDuraklari).ToArray(); // abc de olanları db de olmayan durak idlerinden ayır

            // Foreign Keyleri yerleştirdik
            for (var i = 0; i < dbDeOlmayanDuraklar.Count(); i++)
            {
                GuzergahDurak gdurak = new GuzergahDurak();
                gdurak.Guzergah_Id = Id;
                gdurak.Id = dbDeOlmayanDuraklar[i]; //Arrayden gelen valuelar eklenecek
                gdurak.Siralama = db.GuzergahDurak.Count(x=>x.Guzergah_Id == Id) + 1; // Çünkü tekrar 1 den başlayamaz zaten önceki bir sıra var oradan
                // devam etmeli
                db.GuzergahDurak.Add(gdurak);
            }
            db.SaveChanges();
            error.Add("Guzergah başarıyla güncellenmiştir");
            return error;
        }

        public object GuzergahYoluCiz(string Guzergah_Adi)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            var guzergahId = db.Guzergah.Where(g => g.Guzergah_Adi == Guzergah_Adi).Select(g => g.Guzergah_Id).FirstOrDefault();
            var sonSira = db.GuzergahDurak.Where(g => g.Guzergah_Id == guzergahId).Select(g => g.Siralama).Count();
            duraklariCiz = db.GuzergahDurak.Where(g => g.Guzergah_Id == guzergahId).Select(g => new {
                Id = g.Id,
                Enlem = g.BusStops.Enlem,
                Boylam = g.BusStops.Boylam,
                Durak_Adi = g.BusStops.Durak_Adi,
                Siralama = g.Siralama,
                SonSira = sonSira,
                Guzergah_Id = g.Guzergah_Id
            }).ToArray();
            return duraklariCiz;
        }

        // Kullanıcı durakların sırasını değiştirdiğindeki yeni sıranın güncellenmiş şekilde db e kaydedilmesi
        // Bize bu durakların hangi güzergaha ait olduğu bilgisi lazım
        public void GuzergahYolundakiDuraklariGuncelle(int []array, int Guzergah_Id)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            var guzergahinIdsiniBul = db.GuzergahDurak.Where(x => x.Guzergah_Id == Guzergah_Id).ToArray();
            foreach(var siralama in array)
            {
                
            }
        }
    }
}
    