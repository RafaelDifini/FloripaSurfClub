using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FloripaSurfClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        [HttpPost]
        public IActionResult Criar([FromBody] Professor professor)
        {
            if (professor == null)
                return BadRequest();

            var result = ServiceProfessor.Criar(professor);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao criar o professor.");
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            var professor = ServiceProfessor.Buscar(id);
            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var professores = ServiceProfessor.Listar();
            return Ok(professores);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] Professor professor)
        {
            if (professor == null || professor.Id != id)
                return BadRequest();

            var result = ServiceProfessor.Atualizar(professor);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao atualizar o professor.");
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var result = ServiceProfessor.Remover(id);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao remover o professor.");
        }
    }
}
