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
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    TempData["ShowToast"] = "true";
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login ou senha inválidos.");
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> Registrar()
        {
            ViewBag.TipoUsuarioList = GetTipoUsuarioList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarUsuarioInputModel usuarioInputModel)
        {
            if (!ModelState.IsValid)
                return View(usuarioInputModel);

            var usuario = new UsuarioSistema
            {
                UserName = usuarioInputModel.Email,
                Email = usuarioInputModel.Email,
                Nome = usuarioInputModel.Nome,
                PhoneNumber = usuarioInputModel.Telefone,
                TipoUsuario = usuarioInputModel.TipoUsuario
            };

            var result = await _userManager.CreateAsync(usuario, usuarioInputModel.Senha);

            if (result.Succeeded)
            {
                switch (usuarioInputModel.TipoUsuario)
                {
                    case ETipoUsuario.Aluno:
                        var aluno = new Aluno
                        {
                            UsuarioSistemaId = usuario.Id,
                            Nome = usuarioInputModel.Nome,
                            Peso = usuarioInputModel.Peso.Value,
                            Altura = usuarioInputModel.Altura.Value,
                            Nacionalidade = usuarioInputModel.Nacionalidade,
                            Nivel = usuarioInputModel.Nivel.Value
                        };
                        ServiceAlunos.Criar(aluno);
                        break;
                    case ETipoUsuario.Professor:
                        var professor = new Professor
                        {
                            UsuarioSistemaId = usuario.Id,
                            Nome = usuarioInputModel.Nome,
                            ValorAReceber = 0
                        };
                        ServiceProfessor.Criar(professor);
                        break;
                    case ETipoUsuario.Atendente:
                        var atendente = new Atendente
                        {
                            UsuarioSistemaId = usuario.Id,
                            Nome = usuarioInputModel.Nome,
                            ValorAReceber = 0
                        };
                        ServiceAtendente.Criar(atendente);
                        break;
                    case ETipoUsuario.Cliente:
                        var cliente = new Cliente
                        {
                            Nome = usuarioInputModel.Nome,
                            ValorAPagar = 0,
                            Email = usuarioInputModel.Email,
                            Telefone = usuarioInputModel.Telefone
                        };
                        ServiceCliente.Criar(cliente);
                        break;
                    default:
                        return BadRequest("Tipo de usuário inválido.");
                }

                TempData["ShowToast"] = "true";
                return RedirectToAction("Registrar");
            }
            else
            {
                return StatusCode(500, "Erro ao criar o usuário.");
            }
        }

        private List<SelectListItem> GetTipoUsuarioList()
        {
            return Enum.GetValues(typeof(ETipoUsuario))
                       .Cast<ETipoUsuario>()
                       .Select(e => new SelectListItem
                       {
                           Value = ((int)e).ToString(),
                           Text = e.ToString()
                       }).ToList();
        }
    }

}
