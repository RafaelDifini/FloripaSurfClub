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
using FloripaSurfClubWeb.Models.Account;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace FloripaSurfClubWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly SignInManager<UsuarioSistema> _signInManager;
        private readonly UserManager<UsuarioSistema> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AccountController(SignInManager<UsuarioSistema> signInManager,
                                 UserManager<UsuarioSistema> userManager,
                                 RoleManager<IdentityRole<Guid>> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        public IActionResult RedefinicaoSenha()
        {
            return View("~/Views/Account/RedefinicaoSenha.cshtml");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    loginViewModel.Email, loginViewModel.Senha, loginViewModel.LembrarMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login ou senha inválidos.");
            }

            return View(loginViewModel);
        }



        [HttpPost]
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
