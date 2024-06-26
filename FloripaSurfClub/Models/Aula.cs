using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Models
{
    public class Aula
    {
        public Aula()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public DateTime DataInicio { get; set; }
        public decimal Valor { get; set; }
        public bool EhPacote { get; set; } = false;
        public bool Concluida { get; set; }
    }
}
