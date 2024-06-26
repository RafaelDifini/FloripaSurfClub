using System;

namespace FloripaSurfClub.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public  string Nome { get; set; }
        public UsuarioSistema UsuarioSistema { get; set; }
        public decimal ValorAPagar { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
