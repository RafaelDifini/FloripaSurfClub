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
    public class AtendenteController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AtendenteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            var atendente = ServiceAtendente.Buscar(id);
            if (atendente == null)
                return NotFound();

            var atendenteDto = _mapper.Map<DtoAtendente>(atendente);
            return Ok(atendenteDto);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var atendentes = ServiceAtendente.Listar();
            var atendentesDto = _mapper.Map<List<DtoAtendente>>(atendentes);
            return Ok(atendentesDto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] DtoAtendente atendenteDto)
        {
            if (atendenteDto == null || atendenteDto.Id != id)
                return BadRequest();

            var atendente = _mapper.Map<Atendente>(atendenteDto);
            atendente.Id = id;

            var result = ServiceAtendente.Atualizar(atendente);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao atualizar o atendente.");
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var result = ServiceAtendente.Remover(id);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao remover o atendente.");
        }
    }
}
