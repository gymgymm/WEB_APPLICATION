using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/personel")]
    public class PersonelController : Controller
    {
        private readonly IPersonelRepository _personelRepository;
        public PersonelController(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }

        [HttpPost("ekle")]
        public IActionResult CreatePersonel(Personel personel)
        {
            try
            {
                _personelRepository.CreatPersonel(personel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("sil{personelId}")]
        public IActionResult DeletePersonel(int personelId)
        {
            try
            {
                var existingUye = _personelRepository.GetPersonelId(personelId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _personelRepository.DeletePersonel(personelId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getir{personelId}")]
        public IActionResult GetPersonelId(int personelId)
        {
            try
            {
                var personel = _personelRepository.GetPersonelId(personelId);
                return personel == null ? NotFound() : Ok(personel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetPersonel()
        {
            try
            {
                var personel = _personelRepository.GetPersoneller();
                return Ok(personel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("guncelle{personelId}")]
        public IActionResult UpdateUye(int personelId, Personel personel)
        {
            try
            {
                var existingUye = _personelRepository.GetPersonelId(personelId);
                if (existingUye == null)
                {
                    return NotFound();
                }
                _personelRepository.UpdatePersonel(personelId, personel);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
