using AutoMapper;
using FloripaSurfClub.DTOs;
using FloripaSurfClub.Enums;
using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FloripaSurfClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSistemaController : ControllerBase
    {
        private readonly UserManager<UsuarioSistema> _userManager;
        private readonly IMapper _mapper;

        public UsuarioSistemaController(UserManager<UsuarioSistema> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AlunoDTO usuarioDto)
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
