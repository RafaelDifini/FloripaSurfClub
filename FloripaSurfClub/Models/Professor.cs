using System;
using System.Collections.Generic;

namespace FloripaSurfClub.Models
{
    public class Professor
    {
        public Professor()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValoresAReceber { get; set; }
        public List<Aula> Aulas { get; set; } = new List<Aula>();
    }
}
