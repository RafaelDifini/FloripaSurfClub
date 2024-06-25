using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Models
{
    public class Aula
    {
        public Guid Id { get; set; }
        public Professor Professor { get; set; }
        public Aluno Aluno { get; set; }
        public DateTime DataInicio { get; set; }

        public decimal Valor { get; set; }
        public bool EhPacote { get; set; }
    }
}
