using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using System.Web.Security;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GirisYap(TBLUYELER p)
        {
            p.AD = "knkdf";
            p.ID = 0;
            p.SOYAD = "dgdg";
            p.KULLANICIADI = "ldsmf";
            p.FOTOGRAF = "ldv";
            p.TELEFON = "ödv";
            p.OKUL = "lldf";
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://localhost:1433/api/uye/uyegiris", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        // Hata mesajını loglayabilir veya kullanıcıya daha detaylı bilgi verebilirsiniz.
                        return View("Error");
                    }

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var bilgiler = JsonConvert.DeserializeObject<TBLUYELER>(responseContent);

                    if (bilgiler != null)
                    {
                        FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                        Session["Mail"] = bilgiler.MAIL.ToString();
                        return RedirectToAction("Index", "Panelim");
                    }
                    else
                    {
                        // Kullanıcı bilgileri bulunamadıysa uygun bir mesaj göster
                        return View("LoginError"); // Örnek bir View
                    }
                
                
            }
        }

    }
}