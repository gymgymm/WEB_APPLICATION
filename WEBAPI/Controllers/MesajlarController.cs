using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/mesajlar")]
    public class MesajlarController : Controller
    {
        private readonly IMesajlarRepository _mesajlarRepository;
        public MesajlarController(IMesajlarRepository mesajlarRepository)
        {
            _mesajlarRepository = mesajlarRepository;
        }
        [HttpGet("alicimesaj{mail}")]
        public IActionResult GetMesajlar(string mail)
        {
            try
            {
                var mesajlar = _mesajlarRepository.GetMesajlar(mail);
                return Ok(mesajlar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("gonderilen{mail}")]
        public IActionResult GetMesajlargönderici(string mail)
        {
            try
            {
                
                var mesajlar = _mesajlarRepository.GetMesajlargönderici(mail);
                return Ok(mesajlar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ekle")]
        public IActionResult CreateUye(Mesajlar mesaj)
        {
            try
            {
                _mesajlarRepository.CreateMesaj(mesaj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
