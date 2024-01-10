using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using WebApplication2.Models.Entity;
namespace WebApplication2.Controllers
{
    public class islemController : Controller
    {
        // GET: islem
        public ActionResult Index()
        {   //kitap üyeler ve personel yazıldığında ekle
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/duyuru/islem").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLHAREKET>>(response);
            var degerler = value.ToList();
            //
            List<TBLKITAP> kitapadı = new List<TBLKITAP>();
            List<TBLPERSONEL> personeladı = new List<TBLPERSONEL>();
            List<TBLUYELER> uyeadı = new List<TBLUYELER>();
            foreach (var item in value)
            {

                var kitaprequest = httpClient.GetAsync($"https://localhost:1433/api/kitap/kitapgetir{item.KITAP}").Result;
                var kitapresponse = kitaprequest.Content.ReadAsStringAsync().Result;

                if (!request.IsSuccessStatusCode)
                {
                    // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                    return View("Error");
                }

                var kitap = JsonConvert.DeserializeObject<TBLKITAP>(kitapresponse);
                kitapadı.Add(kitap);
            }
            foreach (var item in value)
            {
                var prsrequest = httpClient.GetAsync($"https://localhost:1433/api/personel/getir{item.PERSONEL}").Result;
                var prsresponse = prsrequest.Content.ReadAsStringAsync().Result;

                if (!request.IsSuccessStatusCode)
                {
                    // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                    return View("Error");
                }
                var personel = JsonConvert.DeserializeObject<TBLPERSONEL>(prsresponse);
                personeladı.Add(personel);
            }
            foreach(var item in value)
            {
                var uyerequest = httpClient.GetAsync($"https://localhost:1433/api/uye/{item.UYE}").Result;
                var uyeresponse = uyerequest.Content.ReadAsStringAsync().Result;

                if (!request.IsSuccessStatusCode)
                {
                    // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                    return View("Error");
                }
                var uye = JsonConvert.DeserializeObject<TBLUYELER>(uyeresponse);
                uyeadı.Add(uye);
            }
            ViewBag.ktp = kitapadı;
            ViewBag.prs = personeladı;
            ViewBag.uye = uyeadı;

            return View(degerler);
        }


    }
}