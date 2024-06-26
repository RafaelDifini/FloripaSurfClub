using System;
using System.Collections.Generic;

namespace FloripaSurfClub.DTOs
{
    public class DtoAula
    {
        public Guid Id { get; set; }
        public Guid ProfessorId { get; set; }
        public DtoProfessor Professor { get; set; }
        public List<Guid> AlunoIds { get; set; } = new List<Guid>();
        public DateTime DataInicio { get; set; }
        public decimal Valor { get; set; }
        public bool EhPacote { get; set; }
        public bool Concluida { get; set; }
    }
}
