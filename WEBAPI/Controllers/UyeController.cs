using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Entities;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/uye")]
    public class UyeController : Controller
    {

        private readonly IUyelerRepository _uyelerRepository;
        public UyeController(IUyelerRepository uyelerRepository)
        {
            _uyelerRepository = uyelerRepository;
        }
        [HttpGet]
        public IActionResult GetUyeler()
        {
            try
            {
                var uyeler = _uyelerRepository.GetUyeler();
                return Ok(uyeler);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{uyeId}")]
        public IActionResult GetUyeId(int uyeId)
        {
            try
            {
                var uye = _uyelerRepository.GetUyeId(uyeId);
                return uye == null ? NotFound() : Ok(uye);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ekle")]
        public IActionResult CreateUye(UyelerDTO uye)
        {
            try
            {
                _uyelerRepository.CreateUye(uye);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("guncelle{uyeId}")]
        public IActionResult  UpdateUye(int uyeId, UyelerDTO uye)
        {
            try
            {
                var existingUye = _uyelerRepository.GetUyeId(uyeId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _uyelerRepository.UpdateUye(uyeId, uye);
                return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("sil{uyeId}")]
        public IActionResult DeleteUye(int uyeId)
        {
            try
            {
                var existingUye = _uyelerRepository.GetUyeId(uyeId);
                if(existingUye == null)
                {
                    return NotFound();
                }
                _uyelerRepository.DeleteUye(uyeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("uyegetir{uyeId}")]
        public ActionResult<string> GetHareket(int uyeId)
        {
            try
            {
                var uyeler = _uyelerRepository.UyeAd(uyeId);
                return Ok(uyeler);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("uyegiris")]
        public IActionResult UyeGiris(Uyeler uyeModel)
        {
            try
            {
                var uye = _uyelerRepository.UyeGiris(uyeModel);
                if (uye != null)
                {
                    // Üye bulundu, üye bilgilerini geri gönder
                    return Ok(uye);
                }
                else
                {
                    // Üye bulunamadı, uygun bir mesaj ile geri dön
                    return NotFound("Kullanıcı bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                // Bir hata oluştu, hata mesajını geri gönder
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("uyegetirmail/{mail}")]
        public IActionResult GetUyeMail(string mail)
        {
            try
            {
                var uye = _uyelerRepository.UyeGetirMail(mail);
                return uye == null ? NotFound() : Ok(uye);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

