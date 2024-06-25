using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloripaSurfClubAPI.Controllers
{
    public class AulaController : Controller
    {
        [HttpPost]
        public IActionResult Agendar([FromBody] Aula aula)
        {
            if (aula == null)
                return BadRequest();

            var result = ServiceAula.AgendarAula(aula);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao criar o professor.");
        }
    }
}
