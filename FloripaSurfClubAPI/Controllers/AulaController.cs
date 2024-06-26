using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloripaSurfClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : Controller
    {
        [HttpPost]
        public IActionResult Agendar([FromBody] Aula aula)
        {
            if (aula == null)
                return BadRequest();

            var result = ServiceAula.Agendar(aula);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao criar o professor.");
        }
    }
}
