using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
namespace WebApplication2.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        public ActionResult Index()
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/uye").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLUYELER>>(response);
            var degerler = value.ToList();
            var kitaprequest = httpClient.GetAsync($"https://localhost:1433/api/kitap/hepsi").Result;
            var kitapresponse = kitaprequest.Content.ReadAsStringAsync().Result;
            var kitapvalue = JsonConvert.DeserializeObject<List<TBLKITAP>>(kitapresponse);
            var degerler1 = kitapvalue.ToList();
            var kitaprequest1 = httpClient.GetAsync($"https://localhost:1433/api/kitap/false").Result;
            var kitapresponse1 = kitaprequest1.Content.ReadAsStringAsync().Result;
            var kitapvalue1 = JsonConvert.DeserializeObject<List<TBLKITAP>>(kitapresponse1);
            var degerler2 = kitapvalue1.ToList();
            var kitaprequest2 = httpClient.GetAsync($"https://localhost:1433/api/cezalar").Result;
            var kitapresponse2 = kitaprequest2.Content.ReadAsStringAsync().Result;
            var kitapvalue2 = JsonConvert.DeserializeObject<List<TBLCEZALAR>>(kitapresponse2);
            var degerler3 = kitapvalue2.ToList();
            float toplampara= (float)degerler3.Sum(k => k.PARA);
            var deger1 = value.Count();
            var deger2 = degerler1.Count();
            var deger3 = degerler2.Count();
            var deger4 = toplampara;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/uye").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLUYELER>>(response);
            var degerler = value.ToList();
            var kitaprequest = httpClient.GetAsync($"https://localhost:1433/api/kitap/hepsi").Result;
            var kitapresponse = kitaprequest.Content.ReadAsStringAsync().Result;
            var kitapvalue = JsonConvert.DeserializeObject<List<TBLKITAP>>(kitapresponse);
            var degerler1 = kitapvalue.ToList();
            var kitaprequest1 = httpClient.GetAsync($"https://localhost:1433/api/kitap/false").Result;
            var kitapresponse1 = kitaprequest1.Content.ReadAsStringAsync().Result;
            var kitapvalue1 = JsonConvert.DeserializeObject<List<TBLKITAP>>(kitapresponse1);
            var degerler2 = kitapvalue1.ToList();
            var kitaprequest2 = httpClient.GetAsync($"https://localhost:1433/api/cezalar").Result;
            var kitapresponse2 = kitaprequest2.Content.ReadAsStringAsync().Result;
            var kitapvalue2 = JsonConvert.DeserializeObject<List<TBLCEZALAR>>(kitapresponse2);
            var degerler3 = kitapvalue2.ToList();
            float toplampara = (float)degerler3.Sum(k => k.PARA);

            var kategorirequest = httpClient.GetAsync("https://localhost:1433/api/kategori").Result;
            var kategoriresponse = kategorirequest.Content.ReadAsStringAsync().Result;
            var kategorivalue = JsonConvert.DeserializeObject<List<TBLKATEGORI>>(kategoriresponse).ToList();

            var ıletisimrequest = httpClient.GetAsync("https://localhost:1433/api/iletisim").Result;
            var iletisimresponse = ıletisimrequest.Content.ReadAsStringAsync().Result;
            var iletisimvalue = JsonConvert.DeserializeObject<List<TBLKATEGORI>>(iletisimresponse).ToList();

            var prosedurrequest = httpClient.GetAsync("https://localhost:1433/api/prosedur").Result;
            var prosedurresponse = prosedurrequest.Content.ReadAsStringAsync().Result;
            var prosedurvalue = JsonConvert.DeserializeObject<Prosedur>(prosedurresponse);
            
            var deger1 = degerler1.Count();
            var deger2 = degerler.Count();
            var deger3 = toplampara;
            var deger4 = degerler2.Count();
            var deger5 = kategorivalue.Count();
            var deger6 = prosedurvalue.EnAktifKisi;
            var deger7 = prosedurvalue.EnCokOkunanKitap;
            var deger8 = prosedurvalue.EnFazlaKitapYazarı;
            var deger9 = prosedurvalue.EnİyiYayınEvi;
            var deger10 = prosedurvalue.EnAktifPersonel;
            var deger11 = iletisimvalue.Count();
            var deger12 = prosedurvalue.BugununEmanetleri;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            return View();
        }
    }
}