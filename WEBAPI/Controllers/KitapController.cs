using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/kitap")]
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;
        public KitapController(IKitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }
        [HttpGet("{p}")]
        public IActionResult GetUyeler(string p)
        {
            try
            {
                var kitaplar = _kitapRepository.GetKitaplar(p);
                return Ok(kitaplar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("hepsi")]
        public IActionResult GetKitaplar()
        {
            try
            {
                var kitaplar = _kitapRepository.GetKitaplar();
                return Ok(kitaplar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("kitapgetir{kitapId}")]
        public IActionResult GetKitapId(int kitapId)
        {
            try
            {
                var uye = _kitapRepository.GetKitapId(kitapId);
                return uye == null ? NotFound() : Ok(uye);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("kitapsil{kitapId}")]
        public IActionResult DeleteKitap(int kitapId)
        {
            try
            {
                var existingUye = _kitapRepository.GetKitapId(kitapId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _kitapRepository.DeleteKitap(kitapId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("true")]
        public IActionResult GetKitaplarTrue()
        {
            try
            {
                var kitaplar = _kitapRepository.GetKitaplarTure();
                return Ok(kitaplar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("false")]
        public IActionResult GetKitaplarFalse()
        {
            try
            {
                var kitaplar = _kitapRepository.GetKitaplarFalse();
                return Ok(kitaplar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ekle")]
        public IActionResult CreateKitap(Kitap kitap)
        {
            try
            {
                _kitapRepository.CreateKitap(kitap);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("guncelle{kitapId}")]
        public IActionResult UpdateKitap(int kitapId, Kitap kitap)
        {
            try
            {
                var existingUye = _kitapRepository.GetKitapId(kitapId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _kitapRepository.UpdateKitap(kitapId, kitap);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
