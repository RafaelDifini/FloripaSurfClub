using AutoMapper;
using FloripaSurfClub.DTOs;
using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloripaSurfClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : Controller
    {
        private readonly IMapper _mapper;

        public AulaController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            var aulas = ServiceAula.Listar();
            var aulasDto = _mapper.Map<List<DtoAula>>(aulas);
            return Ok(aulasDto);
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(Guid id)
        {
            var aula = ServiceAula.Buscar(id);
            if (aula == null)
                return NotFound();

            var aulaDto = _mapper.Map<DtoAula>(aula);
            return Ok(aula);
        }

        [HttpPost]
        public IActionResult Agendar([FromBody] DtoAula aulaDto)
        {
            if (aulaDto == null)
                return BadRequest();

            var aula = new Aula
            {
                ProfessorId = aulaDto.ProfessorId,
                DataInicio = aulaDto.DataInicio,
                Valor = aulaDto.Valor,
                EhPacote = aulaDto.EhPacote,
                Concluida = aulaDto.Concluida,
                Alunos = aulaDto.AlunoIds.Select(id => new Aluno { Id = id }).ToList()
            };

            var result = ServiceAula.Agendar(aula);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao agendar a aula.");
        }



        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] DtoAula aulaDto)
        {
            if (aulaDto == null || aulaDto.Id != id)
                return BadRequest();

            var aula = _mapper.Map<Aula>(aulaDto);
            aula.Id = id;

            var result = ServiceAula.Atualizar(aula);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao atualizar a aula.");
        }



        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var result = ServiceAula.Remover(id);
            if (result)
                return Ok();
            else
                return StatusCode(500, "Erro ao remover o professor.");
        }

    }
}
