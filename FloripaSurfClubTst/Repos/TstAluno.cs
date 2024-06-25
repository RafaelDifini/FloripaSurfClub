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
    public class TstAluno
    {   
        [TestMethod]
        public void CriarAluno()
        {
            Aluno aluno = new Aluno();
            aluno.Nome = "Rafael";
            aluno.Id = Guid.NewGuid();
            aluno.Altura = 180;
            aluno.Nacionalidade = "Brasileiro";
            aluno.Peso = 87;

            bool result = ServiceAlunos.Criar(aluno); 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Listar()
        {
            var lista = ServiceAlunos.Listar();
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void Buscar()
        {
            var id = "71f581e8-2934-46ca-a1dc-1c0015b42297";
            var result = ServiceAlunos.Buscar(Guid.Parse(id));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Atulizar()
        {
            var alunos = ServiceAlunos.Listar();
            var aluno = alunos.FirstOrDefault();
            aluno.Nome = "James";
            aluno.Altura = 180;
            aluno.Nacionalidade = "Neozelandes";
            aluno.Peso = 87;

            bool result = ServiceAlunos.Atualizar(aluno);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remover()
        {
            var id = "71f581e8-2934-46ca-a1dc-1c0015b42297";
            var result = ServiceAlunos.Remover(Guid.Parse(id));
            Assert.IsNotNull(result);
        }
    }

}
