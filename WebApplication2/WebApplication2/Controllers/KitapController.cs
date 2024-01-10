using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap

        public ActionResult Index(string p)
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/kitap/hepsi").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLKITAP>>(response);
            var degerler = value.ToList();
            
            if (!string.IsNullOrEmpty(p))
            {
                var request1 = httpClient.GetAsync($"https://localhost:1433/api/kitap/{p}").Result;
                var response1 = request1.Content.ReadAsStringAsync().Result;
                value = JsonConvert.DeserializeObject<List<TBLKITAP>>(response1);
                //var degerler = db.TBLUYELER.ToList();
                degerler = value.ToList();
                


            }
            var requestyazar = httpClient.GetAsync("https://localhost:1433/api/yazar").Result;
            var responseyazar = requestyazar.Content.ReadAsStringAsync().Result;
            var valueyazar = JsonConvert.DeserializeObject<List<TBLYAZAR>>(responseyazar);
            List<TBLYAZAR> yazar=valueyazar.ToList();
           
            var kategorirequest = httpClient.GetAsync("https://localhost:1433/api/kategori").Result;
            var kategoriresponse = kategorirequest.Content.ReadAsStringAsync().Result;
            var value1 = JsonConvert.DeserializeObject<List<TBLKATEGORI>>(kategoriresponse);
            List<TBLKATEGORI> kategori=value1.ToList();
            ViewBag.yazar= yazar;
            ViewBag.kategori= kategori;

            // List<TBLYAZAR> model2 = new List<TBLYAZAR>();
            //model2.Add(new TBLYAZAR());
            //var model = new Tuple<List<TBLKITAP>, List<TBLYAZAR>>(degerler, model2);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/kategori").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLKATEGORI>>(response);
            var degerler = value.ToList();
            List<TBLKATEGORI> listkategori= value.ToList();
            ViewBag.dgr1 = listkategori;

            var request1 = httpClient.GetAsync("https://localhost:1433/api/yazar").Result;
            var response1 = request1.Content.ReadAsStringAsync().Result;
            var value1 = JsonConvert.DeserializeObject<List<TBLYAZAR>>(response1);
            var degerler1 = value1.ToList();
            List<TBLYAZAR> listyazar= value1.ToList();
            ViewBag.dgr2 = listyazar;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/kategori/kategorigetir{p.TBLKATEGORI.ID}").Result;
            var response = request.Content.ReadAsStringAsync().Result;

            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }

            var ktg = JsonConvert.DeserializeObject<TBLKATEGORI>(response);
            var request1 = httpClient.GetAsync($"https://localhost:1433/api/yazar/{p.TBLYAZAR.ID}").Result;
            var response1 = request.Content.ReadAsStringAsync().Result;

            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }

            var yzr = JsonConvert.DeserializeObject<TBLYAZAR>(response1);
            p.YAZAR = yzr.ID;
            p.KATEGORI = ktg.ID;
            using (var httpClient2 = new HttpClient())
            {
                // JSON formatında yeni üye bilgisini hazırlayın
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP POST isteği ile yeni üye bilgisini API'ye gönderin
                var task = httpClient2.PostAsync("https://localhost:1433/api/kitap/ekle", content);
                task.Wait(); // İstek tamamlanana kadar burada bekler

                var response2 = task.Result; // İstek sonucunu alır

                if (response2.IsSuccessStatusCode)
                {
                    // Ekleme işlemi başarılı
                    return RedirectToAction("Index");
                }
                else
                {
                    // Ekleme işlemi başarısız
                    return View("Error");
                }
            }
            
        }

        public ActionResult KitapSil(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var task = httpClient.DeleteAsync($"https://localhost:1433/api/kitap/kitapsil{id}");
                task.Wait(); // İstek tamamlanana kadar burada bekler

                var response = task.Result; // İstek sonucunu alır

                if (response.IsSuccessStatusCode)
                {
                    // Silme işlemi başarılı
                    return RedirectToAction("Index");
                }
                else
                {
                    // Silme işlemi başarısız
                    return View("Error");
                }
            }
        }

        public ActionResult KitapGetir(int id)
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/kitap/kitapgetir{id}").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }
            var kitap = JsonConvert.DeserializeObject<TBLKITAP>(response);

            
            var kategorirequest = httpClient.GetAsync("https://localhost:1433/api/kategori").Result;
            var kategoriresponse = kategorirequest.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLKATEGORI>>(kategoriresponse);
            var degerler = value.ToList();
            List<TBLKATEGORI> kategori =value.ToList();
            ViewBag.dgr3 = kategori;


            var requestyazar = httpClient.GetAsync("https://localhost:1433/api/yazar").Result;
            var responseyazar = requestyazar.Content.ReadAsStringAsync().Result;
            var value1 = JsonConvert.DeserializeObject<List<TBLYAZAR>>(responseyazar);
            List<TBLYAZAR> yazar = value1.ToList();
           
            ViewBag.dgr4 = yazar;
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBLKITAP p)
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/kitap/kitapgetir{p.ID}").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }
            var kitap = JsonConvert.DeserializeObject<TBLKITAP>(response);

            kitap.AD = p.AD;
            kitap.BASIMYILI = p.BASIMYILI;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            kitap.DURUM = true;
            // var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault(); 
            // var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            // kitap.KATEGORI = ktg.ID;
            //kitap.YAZAR = yzr.ID;
            // db.SaveChanges();   
            using (var httpClient1 = new HttpClient())
            {
                // API'nin tam URL'sini belirtin
                var url = $"https://localhost:1433/api/kitap/guncelle{p.ID}";

                // nesneyi JSON'a dönüştürün
                var json = JsonConvert.SerializeObject(kitap);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP PUT isteği gönderin ve sonucunu bekleyin
                var responseTask = httpClient1.PutAsync(url, content);
                responseTask.Wait(); // İstek tamamlanana kadar burada bekleyin

                var response1 = responseTask.Result; // İstek sonucunu alın
                if (response1.IsSuccessStatusCode)
                {
                    // Başarılı güncelleme durumunda anasayfaya yönlendir
                    return RedirectToAction("Index");
                }
                else
                {
                    // Hata durumunda bir hata sayfası görüntüleyin
                    return View("Error");
                }
            }
              


        }
    }
}