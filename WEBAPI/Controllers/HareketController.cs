using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/hareket")]
    public class HareketController : Controller
    {
        private readonly IHareket _hareket;
        public HareketController(IHareket hareket)
        {
            _hareket = hareket;
        }
        [HttpGet("gecmis{ıd}")]
        public ActionResult Hareket(int ıd)
        {
            try
            {
                var uye = _hareket.HareketGecmis(ıd);
                return uye == null ? NotFound() : Ok(uye);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult GetHareketler()
        {
            try
            {
                var hareketler = _hareket.GetHareketler();
                return Ok(hareketler);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ekle")]
        public IActionResult CreateHareket(Hareket hareket)
        {
            try
            {
                _hareket.CreateHareket(hareket);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getir{hareketId}")]
        public IActionResult GetHareketId(int hareketId)
        {
            try
            {
                var hareket = _hareket.GetHareketId(hareketId);
                return hareket == null ? NotFound() : Ok(hareket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("guncelle{hareketId}")]
        public IActionResult UpdateHareket(int hareketId, Hareket hareket)
        {
            try
            {
                var existingUye = _hareket.GetHareketId(hareketId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _hareket.UpdateHareket(hareketId, hareket);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("uyehareket{id}")]
        public IActionResult GetHareketlerUye(int id)
        {
            try
            {
                var hareketler = _hareket.GetUyeHareketler(id);
                return Ok(hareketler);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
