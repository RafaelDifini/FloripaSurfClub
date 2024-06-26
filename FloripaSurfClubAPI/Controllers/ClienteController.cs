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
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            var cliente = ServiceCliente.Buscar(id);
            if (cliente == null)
                return NotFound();

            var clienteDto = _mapper.Map<DtoCliente>(cliente);
            return Ok(clienteDto);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var clientes = ServiceCliente.Listar();
            var clientesDto = _mapper.Map<List<DtoCliente>>(clientes);
            return Ok(clientesDto);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] DtoCliente clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var cliente = _mapper.Map<Cliente>(clienteDto);
            var result = ServiceCliente.Criar(cliente);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao criar o cliente.");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] DtoCliente clienteDto)
        {
            if (clienteDto == null || clienteDto.Id != id)
                return BadRequest();

            var clienteExistente = ServiceCliente.Buscar(id);
            if (clienteExistente == null)
                return NotFound();

            var cliente = _mapper.Map(clienteDto, clienteExistente);
            var result = ServiceCliente.Atualizar(cliente);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao atualizar o cliente.");
        }
    }
}
