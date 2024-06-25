using FloripaSurfClub.Models;
using FloripaSurfClub.Repositories;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FloripaSurfClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Criar([FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest();

            var result = ServiceAlunos.Criar(aluno);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao criar o aluno.");
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            var aluno = ServiceAlunos.Buscar(id);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var alunos = ServiceAlunos.Listar();
            return Ok(alunos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] Aluno aluno)
        {
            if (aluno == null || aluno.Id != id)
                return BadRequest();

            var result = ServiceAlunos.Atualizar(aluno);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao atualizar o aluno.");
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var result = ServiceAlunos.Remover(id);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao remover o aluno.");
        }
    }
}
