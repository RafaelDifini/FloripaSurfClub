using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using FloripaSurfClub.DTOs;
using FloripaSurfClub.Models;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FloripaSurfClub.Enums;
using FloripaSurfClub.Services;

namespace FloripaSurfClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UsuarioSistema> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public AccountController(UserManager<UsuarioSistema> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] DtoAluno usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest();

            var usuario = new UsuarioSistema
            {
                UserName = usuarioDto.Email,
                Email = usuarioDto.Email,
                Nome = usuarioDto.Nome,
                PhoneNumber = usuarioDto.Telefone,
                TipoUsuario = usuarioDto.TipoUsuario
            };

            var result = await _userManager.CreateAsync(usuario, usuarioDto.Password);

            if (result.Succeeded)
            {
                switch (usuarioDto.TipoUsuario)
                {
                    case ETipoUsuario.Aluno:
                        var aluno = new Aluno
                        {
                            UsuarioSistemaId = usuario.Id,
                            Nome = usuarioDto.Nome,
                            Peso = usuarioDto.Peso,
                            Altura = usuarioDto.Altura,
                            Nacionalidade = usuarioDto.Nacionalidade,
                            Nivel = usuarioDto.Nivel
                        };
                        ServiceAlunos.Criar(aluno);
                        break;
                    case ETipoUsuario.Professor:
                        var professor = new Professor
                        {
                            UsuarioSistemaId = usuario.Id,
                            Nome = usuarioDto.Nome,
                            ValorAReceber = 0
                        };
                        ServiceProfessor.Criar(professor);
                        break;
                    case ETipoUsuario.Atendente:
                        var atendente = new Atendente
                        {
                            UsuarioSistemaId = usuario.Id,
                            Nome = usuarioDto.Nome,
                            ValorAReceber = 0
                        };
                        ServiceAtendente.Criar(atendente);
                        break;
                    case ETipoUsuario.Cliente:
                        var cliente = new Cliente
                        {
                            Nome = usuarioDto.Nome,
                            ValorAPagar = 0,
                            Email = usuarioDto.Email,
                            Telefone = usuarioDto.Telefone
                        };
                        ServiceCliente.Criar(cliente);
                        break;
                    default:
                        return BadRequest("Tipo de usuário inválido.");
                }

                return Ok();
            }
            else
            {
                return StatusCode(500, "Erro ao criar o usuário.");
            }
        }
    }
}
