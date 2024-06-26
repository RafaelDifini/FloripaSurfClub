using FloripaSurfClub.DTOs;
using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloripaSurfClubAPI.Controllers
{
    public class CaixaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AbrirCaixa([FromBody] Caixa caixa)
        {
            if (caixa == null)
                return BadRequest();

            var result = ServiceCaixa.AbrirCaixa(caixa);
            if (result)
                return Created();

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] Caixa caixa)
        {
            if (caixa == null || id == Guid.Empty)
                return BadRequest();

            var caixaExistente = ServiceCaixa.Buscar(id);

            caixaExistente.ValorTotal = caixa.ValorTotal;
            caixaExistente.DataFechamento = caixa.DataFechamento;

            var result = ServiceCaixa.Atualizar(caixaExistente);
            if (result)
                return Created();

            return BadRequest();
        }
    }
}
