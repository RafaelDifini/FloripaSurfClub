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
    public class TstProfessor
    {

        [TestMethod]
        public void Criar()
        {
            Professor professor = new Professor();
            professor.Nome = "Roger";
            professor.UsuarioSistema.Id = Guid.NewGuid();

            bool result = ServiceProfessor.Criar(professor);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Listar()
        {
            var lista = ServiceProfessor.Listar();
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void VerificarDisponibilidade()
        {
            var prefessores = ServiceProfessor.Listar();

            var professor = prefessores.FirstOrDefault();

            var dataVerificacao = new DateTime(2024, 6, 26, 15,0,0);
            bool disponivel = ServiceProfessor.EstaDisponivel(professor, dataVerificacao);

            Assert.IsFalse(disponivel);
        }

        [TestMethod]
        public void Buscar()
        {
            var id = "71f581e8-2934-46ca-a1dc-1c0015b42297";
            var result = ServiceProfessor.Buscar(Guid.Parse(id));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Atulizar()
        {
            var professores = ServiceProfessor.Listar();
            var professor = professores.FirstOrDefault();

            professor.Nome = "Rafael";
            professor.ValorAReceber = 150;

            bool result = ServiceProfessor.Atualizar(professor);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remover()
        {
            var id = "71f581e8-2934-46ca-a1dc-1c0015b42297";
            var result = ServiceProfessor.Remover(Guid.Parse(id));
            Assert.IsNotNull(result);
        }
    }
}
