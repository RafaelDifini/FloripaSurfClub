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
    public class ProfessorController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProfessorController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            var professor = ServiceProfessor.Buscar(id);
            if (professor == null)
                return NotFound();

            var professorDto = _mapper.Map<ProfessorDTO>(professor);
            return Ok(professorDto);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var professores = ServiceProfessor.Listar();
            var professoresDto = _mapper.Map<List<ProfessorDTO>>(professores);
            return Ok(professoresDto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] ProfessorDTO professorDto)
        {
            if (professorDto == null || professorDto.Id != id)
                return BadRequest();

            var professorExistente = ServiceProfessor.Buscar(id);
            if (professorExistente == null)
                return NotFound();

            // Atualizar apenas os campos necessários
            professorExistente.Nome = professorDto.Nome;
            professorExistente.ValorAReceber = professorDto.ValorAReceber;

            var result = ServiceProfessor.Atualizar(professorExistente);
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
