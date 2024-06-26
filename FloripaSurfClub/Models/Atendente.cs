using System;

namespace FloripaSurfClub.Models
{
    public class Atendente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid UsuarioSistemaId { get; set; }
        public UsuarioSistema UsuarioSistema { get; set; }
        public decimal ValorAReceber { get; set; }
    }
}
