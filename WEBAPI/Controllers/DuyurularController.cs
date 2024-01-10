using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/duyuru")]
    public class DuyurularController : Controller
    {
        private readonly IDuyuruRepository _duyuruRepository;
        public DuyurularController(IDuyuruRepository duyuruRepository)
        {
            _duyuruRepository = duyuruRepository;
        }
        [HttpGet]
        public IActionResult GetDuyurular()
        {
            try
            {
                var duyurular = _duyuruRepository.GetDuyurular();
                return Ok(duyurular);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ekle")]
        public IActionResult CreateDuyuru(Duyuru duyuru)
        {
            try
            {
                _duyuruRepository.CreateDuyuru(duyuru);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{duyuruId}")]
        public IActionResult GetDuyuruId(int duyuruId)
        {
            try
            {
                var duyuru = _duyuruRepository.GetDuyuruId(duyuruId);
                return duyuru == null ? NotFound() : Ok(duyuru);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("sil{duyuruId}")]
        public IActionResult DeleteDuyuru(int duyuruId)
        {
            try
            {
                var existingDuyuru = _duyuruRepository.GetDuyuruId(duyuruId);
                if (existingDuyuru == null)
                {
                    return NotFound();
                }
                _duyuruRepository.DeleteDuyuru(duyuruId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("guncelle{duyuruId}")]
        public IActionResult UpdateUye(int duyuruId, Duyuru duyuru)
        {
            try
            {
                var existingUye = _duyuruRepository.GetDuyuruId(duyuruId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _duyuruRepository.UpdateDuyuru(duyuruId, duyuru);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("islem")]
        public IActionResult DuyuruIslem()
        {
            try
            {
                var uyeler = _duyuruRepository.DuyuruIslem();
                return Ok(uyeler);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
