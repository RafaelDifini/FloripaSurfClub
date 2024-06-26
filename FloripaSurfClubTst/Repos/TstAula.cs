using FloripaSurfClub.Migrations;
using FloripaSurfClub.Models;
using FloripaSurfClub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClubTst.Repos
{
    [TestClass]
    public class TstAula
    {
        [TestMethod]
        public void AgendarAula()
        {
            var professor = ServiceProfessor.Listar().FirstOrDefault();
            var aluno = ServiceAlunos.Listar().FirstOrDefault();

            if (professor == null || aluno == null)
            {
                Assert.Fail("Professor ou Aluno não encontrados.");
            }

            var aula = new Aula
            {
                Id = Guid.NewGuid(),
                ProfessorId = professor.Id,
                Professor = professor,
                Valor = 150,
                DataInicio = DateTime.Today.AddDays(1).AddHours(15), 
                Alunos = new List<Aluno> { aluno } 
            };

            var result = ServiceAula.Agendar(aula);
            Assert.IsTrue(result, "Erro ao agendar a aula.");

            var aulaAgendada = ServiceAula.Buscar(aula.Id);
            Assert.IsNotNull(aulaAgendada, "Aula não encontrada após o agendamento.");
            Assert.AreEqual(aula.Id, aulaAgendada.Id, "ID da aula agendada incorreto.");
            Assert.AreEqual(professor.Id, aulaAgendada.ProfessorId, "ID do professor incorreto na aula agendada.");
            Assert.AreEqual(1, aulaAgendada.Alunos.Count, "Número incorreto de alunos na aula agendada.");
            Assert.AreEqual(aluno.Id, aulaAgendada.Alunos.First().Id, "ID do aluno incorreto na aula agendada.");
        }


        [TestMethod]
        public void Buscar()
        {
            var aulas = ServiceAula.Listar();

            if(aulas.Count > 0)
            {
                var aula = ServiceAula.Buscar(aulas.FirstOrDefault().Id);

                Assert.IsNotNull(aula);
            }
        }


    }
}
