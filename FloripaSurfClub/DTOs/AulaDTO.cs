using System;

namespace FloripaSurfClub.DTOs
{
    public class AulaDTO
    {
        public Guid Id { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid AlunoId { get; set; }
        public DateTime DataInicio { get; set; }
        public decimal Valor { get; set; }
        public bool EhPacote { get; set; }
        public bool Concluida { get; set; }
    }
}
