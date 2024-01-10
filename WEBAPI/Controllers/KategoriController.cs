using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/kategori")]
    public class KategoriController : Controller
    {
        private readonly IKategoriRepository _kategoriRepository;
        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        [HttpGet]
        public IActionResult GetKategori()
        {
            try
            {
                var duyuru = _kategoriRepository.GetKategori();
                return Ok(duyuru);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ekle")]
        public IActionResult CreateKategori(Kategori kategori)
        {
            try
            {
                _kategoriRepository.CreateKategori(kategori);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("kategorigetir{kategoriId}")]
        public IActionResult GetKategoriId(int kategoriId)
        {
            try
            {
                var uye = _kategoriRepository.GetKategoriId(kategoriId);
                return uye == null ? NotFound() : Ok(uye);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("sil{kategoriId}")]
        public IActionResult DeleteKategori(int kategoriId)
        {
            try
            {
                var existingUye = _kategoriRepository.GetKategoriId(kategoriId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _kategoriRepository.DeleteKategori(kategoriId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("guncelle{kategoriId}")]
        public IActionResult UpdateKategori(int kategoriId, Kategori kategori)
        {
            try
            {
                var existingKategori = _kategoriRepository.GetKategoriId(kategoriId);
                if (existingKategori == null)
                {
                    return NotFound();
                }
                _kategoriRepository.UpdateKategori(kategoriId, kategori);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
