using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/hakkımızda")]
    public class HakkımızdaController : Controller
    {
        private readonly IHakkımızdaRepository _hakkımızdaRepository;
        public HakkımızdaController(IHakkımızdaRepository hakkımızdaRepository)
        {
            _hakkımızdaRepository = hakkımızdaRepository;
        }
        [HttpGet]
        public IActionResult GetHakkımızda()
        {
            try
            {
                var hakkımızda = _hakkımızdaRepository.GetHakkımızda();
                return Ok(hakkımızda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
