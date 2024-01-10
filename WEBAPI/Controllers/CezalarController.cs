using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/cezalar")]
    public class CezalarController : Controller
    {
        private readonly ICezalarRepository _cezalarRepository;
        public CezalarController(ICezalarRepository cezalarRepository)
        {
            _cezalarRepository = cezalarRepository;
        }
        [HttpGet]
        public IActionResult GetCezalar()
        {
            try
            {
                var cezalar = _cezalarRepository.GetCezalar();
                return Ok(cezalar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
