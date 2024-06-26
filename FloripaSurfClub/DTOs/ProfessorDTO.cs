using FloripaSurfClub.Enums;
using System;
using System.Collections.Generic;

namespace FloripaSurfClub.DTOs
{
    public class ProfessorDTO : UsuarioSistemaDTO
    {
        public decimal ValorAReceber { get; set; }
        public List<AulaDTO>? Aulas { get; set; } = new List<AulaDTO>();
    }
}
