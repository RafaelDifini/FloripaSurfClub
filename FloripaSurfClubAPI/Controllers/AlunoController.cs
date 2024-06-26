using AutoMapper;
using FloripaSurfClub.DTOs;
using FloripaSurfClub.Models;
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
        private readonly IMapper _mapper;

        public AlunoController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            var aluno = ServiceAlunos.Buscar(id);
            if (aluno == null)
                return NotFound();

            var alunoDto = _mapper.Map<DtoAluno>(aluno);
            return Ok(alunoDto);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var alunos = ServiceAlunos.Listar();
            var alunosDto = _mapper.Map<List<DtoAluno>>(alunos);
            return Ok(alunosDto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] DtoAluno alunoDto)
        {
            if (alunoDto == null || alunoDto.Id != id)
                return BadRequest();

            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.Id = id;

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
