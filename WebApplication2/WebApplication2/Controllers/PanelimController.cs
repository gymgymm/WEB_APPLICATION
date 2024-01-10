using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/uye/uyegetirmail/{uyemail}").Result;
            var response = request.Content.ReadAsStringAsync().Result;

            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }
            var degerler = JsonConvert.DeserializeObject<TBLUYELER>(response);
            return View(degerler);
        }
        [HttpPost]
       

        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/uye/uyegetirmail/{kullanici}").Result;
            var response = request.Content.ReadAsStringAsync().Result;

            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }
            var degerler = JsonConvert.DeserializeObject<TBLUYELER>(response);

            var hareketrequest = httpClient.GetAsync($"https://localhost:1433/api/hareket/uyehareket{degerler.ID}").Result;
            var hareketresponse = hareketrequest.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLHAREKET>>(hareketresponse);

            var kitaprequest = httpClient.GetAsync($"https://localhost:1433/api/kitap/hepsi").Result;
            var kitapresponse = kitaprequest.Content.ReadAsStringAsync().Result;
            var kitap = JsonConvert.DeserializeObject<List<TBLKITAP>>(kitapresponse);
            ViewBag.ktp=kitap.ToList();
            return View(value.ToList());
        }

        public ActionResult Duyurular()
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/duyuru").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLDUYURULAR>>(response);
            var degerler = value.ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}