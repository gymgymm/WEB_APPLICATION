using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
namespace WebApplication2.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        public async Task<ActionResult> Index()
        {
            var uyemail = Session["Mail"] as string;
            if (string.IsNullOrEmpty(uyemail))
            {
                // Uygun bir hata mesajı veya başka bir işlem yapın
                return View("Error"); // veya başka bir view
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:1433/api/mesajlar/alicimesaj{Uri.EscapeDataString(uyemail)}");
            if (!response.IsSuccessStatusCode)
            {
                // HTTP isteği başarısız oldu, uygun bir işlem yapın
                return View("Error"); // veya başka bir view
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var bilgiler = JsonConvert.DeserializeObject<List<TBLMESAJLAR>>(responseContent);
            return View(bilgiler);
        }

        
        public async Task<ActionResult> Giden()
        {
            var uyemail = Session["Mail"] as string;
            if (string.IsNullOrEmpty(uyemail))
            {
                // Uygun bir hata mesajı veya başka bir işlem yapın
                return View("Error"); // veya başka bir view
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:1433/api/mesajlar/gonderilen{Uri.EscapeDataString(uyemail)}");
            if (!response.IsSuccessStatusCode)
            {
                // HTTP isteği başarısız oldu, uygun bir işlem yapın
                return View("Error"); // veya başka bir view
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var bilgiler = JsonConvert.DeserializeObject<List<TBLMESAJLAR>>(responseContent);
            return View(bilgiler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemail = (string)Session["Mail"].ToString();

            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());

            using (var httpClient = new HttpClient())
            {
                // JSON formatında yeni üye bilgisini hazırlayın
                var json = JsonConvert.SerializeObject(t);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // HTTP POST isteği ile yeni üye bilgisini API'ye gönderin
                var task = httpClient.PostAsync("https://localhost:1433/api/mesajlar/ekle", content);
                task.Wait(); // İstek tamamlanana kadar burada bekler

                var response = task.Result; // İstek sonucunu alır

                if (response.IsSuccessStatusCode)
                {
                    // Ekleme işlemi başarılı
                    return RedirectToAction("Giden", "Mesajlar");
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