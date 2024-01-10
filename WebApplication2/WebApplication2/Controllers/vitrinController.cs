using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using WebApplication2.Models.Siniflarim;
namespace WebApplication2.Controllers
{
    public class vitrinController : Controller
    {
        // GET: vitrin
        [HttpGet]
        public ActionResult Index()
        {   
            Class1 cs = new Class1();
            var httpClient = new HttpClient();
            var request = httpClient.GetAsync("https://localhost:1433/api/kitap/hepsi").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<TBLKITAP>>(response);
            cs.Deger1=value.ToList();
            var request1 = httpClient.GetAsync("https://localhost:1433/api/kitap/hepsi").Result;
            var response1 = request1.Content.ReadAsStringAsync().Result;
            var value1 = JsonConvert.DeserializeObject<List<TBLHAKKIMIZDA>>(response1);
            cs.Deger2= value1.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            using (var httpClient = new HttpClient())
            {
                // JSON formatında yeni üye bilgisini hazırlayın
                var json = JsonConvert.SerializeObject(t);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP POST isteği ile yeni üye bilgisini API'ye gönderin
                var task = httpClient.PostAsync("https://localhost:1433/api/iletisim/ekle", content);
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
    }
}