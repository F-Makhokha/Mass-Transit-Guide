using Staj_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj_Proje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {   /*
              Veritabanına bağlanılır, bilgiler alınır
              Getirilen bilgiler bir model içerisine atılır
              Ve bu model view a gönderilir
            */
            LoginModel login = new LoginModel();
            login.listOfUsers = new List<LoginModel>();
            return View(login);
        }

        [HttpPost]
        public ActionResult Index(string username, string pwd) // password, username check, parametre isimleri                                                     
            // viewdakilerle aynı olamlı
        { 
            LoginModel login = new LoginModel();
            login.listOfUsers = new List<LoginModel>();
            login.ShowAll();
            login.username = username;
            login.pwd = pwd;
            bool loginSuccesed = login.Login(login.username, login.pwd);

            if (loginSuccesed == true)
            {
                // redirect to map
                return RedirectToAction("Index","Map",new { area = "" });
            }
            else
            {
                ViewBag.HtmlStr = "<p class='efe'>Your password is wrong.<p>" +
                    "<p class='efe'>Users Table Contents:</p>" +
                    "<tr class='user-list-table'>"+
                    "</tr>";
                // show an error message
            }

            return View(login);   
        }
    }
}