using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj_Proje.Models
{
    public class LoginModel
    {
        //public int Id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; } // password yazmadım, çünkü orjinal sayfada adı pwd yapmışalar
        // bu yüzden değeri formda null dönüyordu 
        public List<LoginModel> listOfUsers; // username ve password tutar
        
        // Username ve Passwordu check eder, eğer eşleşme varsa harita sayfasını açar, eğer eşleşme
        // yoksa login ekranına geri döner ve yanlış şifre girdiniz der
        public bool Login (string username, string password)
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            var loginInfos = db.Users;
            return loginInfos.Any(b => b.username == this.username && b.pwd == pwd); // LINQ kullanarak DB
            // kontrol edildi
        }

        // DB' deki herkesi gösterir, username ve passwordlarıyla birlikte
        public void ShowAll()
        {
            MassTransitGuide_EfeEntities db = new MassTransitGuide_EfeEntities();
            var loginInfos = db.Users;
            listOfUsers = new List<LoginModel>();
            foreach(var logininfos in loginInfos)
            {
                listOfUsers.Add(new LoginModel() { username = logininfos.username,
                    pwd = logininfos.pwd });
            }
        }
    }
}