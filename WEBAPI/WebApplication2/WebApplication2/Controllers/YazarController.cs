using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
namespace WebApplication2.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar

        public ActionResult Index()
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/yazar").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLYAZAR>>(response);
            var degerler = value.ToList();
            return View(degerler);

        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            using (var httpClient = new HttpClient())
            {
                // JSON formatında yeni üye bilgisini hazırlayın
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP POST isteği ile yeni üye bilgisini API'ye gönderin
                var task = httpClient.PostAsync("https://localhost:1433/api/yazar/ekle", content);
                task.Wait(); // İstek tamamlanana kadar burada bekler

                var response = task.Result; // İstek sonucunu alır

                if (response.IsSuccessStatusCode)
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
        public ActionResult YazarSil(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var task = httpClient.DeleteAsync($"https://localhost:1433/api/yazar/sil{id}");
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
        public ActionResult YazarGetir(int id)
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/yazar/{id}").Result;
            var response = request.Content.ReadAsStringAsync().Result;

            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }

            var yzr = JsonConvert.DeserializeObject<TBLYAZAR>(response);
            
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            if (string.IsNullOrEmpty(p.DETAY))
            {
                p.DETAY = " ";
            }
            int id = p.ID;
            using (var httpClient = new HttpClient())
            {
                // API'nin tam URL'sini belirtin
                var url = $"https://localhost:1433/api/yazar/guncelle{id}";

                // nesneyi JSON'a dönüştürün
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP PUT isteği gönderin ve sonucunu bekleyin
                var responseTask = httpClient.PutAsync(url, content);
                responseTask.Wait(); // İstek tamamlanana kadar burada bekleyin

                var response = responseTask.Result; // İstek sonucunu alın
                if (response.IsSuccessStatusCode)
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
        public ActionResult YazarKitaplar(int id)
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/yazar/kitap{id}").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLKITAP>>(response);
            var yazar = value.ToList();
            var request1 = httpClient.GetAsync($"https://localhost:1433/api/yazar/{id}").Result;
            var response1 = request1.Content.ReadAsStringAsync().Result;

            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }

            var değer1 = JsonConvert.DeserializeObject<TBLYAZAR>(response1);
            var yzrad = değer1.AD + "    " + değer1.SOYAD;
            var kategorirequest = httpClient.GetAsync("https://localhost:1433/api/kategori").Result;
            var kategoriresponse = kategorirequest.Content.ReadAsStringAsync().Result;
            var value1 = JsonConvert.DeserializeObject<List<TBLKATEGORI>>(kategoriresponse);
            List<TBLKATEGORI> list = value1.ToList();
            ViewBag.list = list;
            ViewBag.yzr1 = yzrad;
            return View(yazar);
           
        }
    }
}