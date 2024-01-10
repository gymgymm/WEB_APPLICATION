using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/iletisim")]
    public class IletısımController : Controller
    {
         private readonly IIletisimRepository _ıletisimRepository;
        public IletısımController(IIletisimRepository ıletisimRepository)
        {
            _ıletisimRepository = ıletisimRepository;
        }
        [HttpPost("ekle")]
        public IActionResult CreateIletisim(Iletisim ıletisim)
        {
            try
            {
                _ıletisimRepository.CreateIleisim(ıletisim);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetIletisim()
        {
            try
            {
                var iletisim = _ıletisimRepository.GetIletisim();
                return Ok(iletisim);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
