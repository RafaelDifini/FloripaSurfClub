using AutoMapper;
using FloripaSurfClub.DTOs;
using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FloripaSurfClubWeb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IMapper _mapper;

        public AlunoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var alunos = ServiceAlunos.Listar();
            var alunosDto = _mapper.Map<List<DtoAluno>>(alunos);
            return View(alunosDto);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var aluno = ServiceAlunos.Buscar(id);
            if (aluno == null)
                return NotFound();

            var alunoDto = _mapper.Map<DtoAluno>(aluno);
            return View(alunoDto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DtoAluno alunoDto)
        {
            if (ModelState.IsValid)
            {
                var aluno = _mapper.Map<Aluno>(alunoDto);
                ServiceAlunos.Criar(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(alunoDto);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var aluno = ServiceAlunos.Buscar(id);
            if (aluno == null)
            {
                return NotFound();
            }
            var alunoDto = _mapper.Map<DtoAluno>(aluno);
            return View(alunoDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, DtoAluno alunoDto)
        {
            if (id != alunoDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var aluno = _mapper.Map<Aluno>(alunoDto);
                ServiceAlunos.Atualizar(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(alunoDto);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var aluno = ServiceAlunos.Buscar(id);
            if (aluno == null)
            {
                return NotFound();
            }
            var alunoDto = _mapper.Map<DtoAluno>(aluno);
            return View(alunoDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var result = ServiceAlunos.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
