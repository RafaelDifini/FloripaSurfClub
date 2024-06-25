using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Models
{
    public class Aluguel
    {
        public Guid Id { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Valor { get; set; }
        public bool Encerrado { get; set; }

    }
}
