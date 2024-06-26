using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Models
{
    public class Cliente : Pessoa
    {
        public decimal ValorAPagar { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}
