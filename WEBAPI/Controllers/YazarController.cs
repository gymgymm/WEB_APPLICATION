using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/yazar")]
    public class YazarController : Controller
    {
        private readonly IYazarRepository _yazarRepository;
        public YazarController(IYazarRepository yazarRepository)
        {
            _yazarRepository = yazarRepository;
        }
        [HttpPost("ekle")]
        public IActionResult CreateYazar(Yazar yazar)
        {
            try
            {
                _yazarRepository.CreateYazar(yazar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("sil{yazarId}")]
        public IActionResult DeleteYazar(int yazarId)
        {
            try
            {
                var existingUye = _yazarRepository.GetYazarId(yazarId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _yazarRepository.DeleteYazar(yazarId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{yazarId}")]
        public IActionResult GetYazarId(int yazarId)
        {
            try
            {
                var uye = _yazarRepository.GetYazarId(yazarId);
                return uye == null ? NotFound() : Ok(uye);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetYazarlar()
        {
            try
            {
                var yazarlar = _yazarRepository.GetYazarlar();
                return Ok(yazarlar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("guncelle{yazarId}")]
        public IActionResult UpdateYazar(int yazarId, Yazar yazar)
        {
            try
            {
                var existingUye = _yazarRepository.GetYazarId(yazarId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _yazarRepository.UpdateYazar(yazarId, yazar);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("kitap{yazarId}")]
        public IActionResult GetYazarkitap(int yazarId)
        {
            try
            {
                var yazarlar = _yazarRepository.GetYazarKitap(yazarId);
                return Ok(yazarlar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
