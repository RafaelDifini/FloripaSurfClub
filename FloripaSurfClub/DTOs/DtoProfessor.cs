using FloripaSurfClub.Enums;
using System;
using System.Collections.Generic;

namespace FloripaSurfClub.DTOs
{
    public class DtoProfessor : DtoUsuarioSistema
    {
        public decimal ValorAReceber { get; set; }
        public List<DtoAula>? Aulas { get; set; } = new List<DtoAula>();
    }
}
