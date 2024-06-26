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

            var professorDto = _mapper.Map<DtoProfessor>(professor);
            return Ok(professorDto);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var professores = ServiceProfessor.Listar();
            var professoresDto = _mapper.Map<List<DtoProfessor>>(professores);
            return Ok(professoresDto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] DtoProfessor professorDto)
        {
            if (professorDto == null || professorDto.Id != id)
                return BadRequest();

            var professor = _mapper.Map<Professor>(professorDto);
            professor.Id = id;

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
