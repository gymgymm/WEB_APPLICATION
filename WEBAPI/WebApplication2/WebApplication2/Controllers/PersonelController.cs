using Newtonsoft.Json;
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
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/personel").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLPERSONEL>>(response);
            var degerler = value.ToList();
            return View(degerler);
            
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL p)
        {
            using (var httpClient = new HttpClient())
            {
                // JSON formatında yeni üye bilgisini hazırlayın
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP POST isteği ile yeni üye bilgisini API'ye gönderin
                var task = httpClient.PostAsync("https://localhost:1433/api/personel/ekle", content);
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
        public ActionResult PersonelSil(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var task = httpClient.DeleteAsync($"https://localhost:1433/api/personel/sil{id}");
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
        public ActionResult PersonelGetir(int id)
        {
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync($"https://localhost:1433/api/personel/getir{id}").Result;
            var response = request.Content.ReadAsStringAsync().Result;

            if (!request.IsSuccessStatusCode)
            {
                // Eğer istek başarısızsa, hata sayfası veya uygun bir mesaj göster
                return View("Error");
            }

            var personel = JsonConvert.DeserializeObject<TBLPERSONEL>(response);
            return View("PersonelGetir", personel);
            
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            int id = p.ID;
            using (var httpClient = new HttpClient())
            {
                // API'nin tam URL'sini belirtin
                var url = $"https://localhost:1433/api/personel/guncelle{id}";

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
    }
}