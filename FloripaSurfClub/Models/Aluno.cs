using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Models
{
    public class Aluno : Cliente
    {
        public decimal Peso { get; set; }
        public int Altura { get; set; }
        public  string Nacionalidade { get; set; }
    }
}
