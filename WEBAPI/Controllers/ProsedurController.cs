using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/prosedur")]
    public class ProsedurController : Controller
    {
        private readonly IProsedurRepository _prosedurRepository;
        public ProsedurController(IProsedurRepository prosedurRepository)
        {
            _prosedurRepository = prosedurRepository;
        }
        [HttpGet]
        public IActionResult GetProsedur()
        {
            try
            {
                var prosedur = _prosedurRepository.GetProsedur();
                return Ok(prosedur);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
