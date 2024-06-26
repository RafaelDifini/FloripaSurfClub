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
                Id = Guid.NewGuid(), // Gera um novo ID único para a aula
                ProfessorId = professor.Id,
                AlunoId = aluno.Id,
                Professor = professor,
                Aluno = aluno,
                Valor = 150,
                DataInicio = DateTime.Today.AddDays(1).AddHours(15) // Amanhã às 15h
            };

            var result = ServiceAula.Agendar(aula);
            Assert.IsTrue(result, "Erro ao agendar a aula.");
        }


    }
}
