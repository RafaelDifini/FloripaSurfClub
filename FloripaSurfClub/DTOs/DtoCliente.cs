using FloripaSurfClub.Enums;
using System;

namespace FloripaSurfClub.DTOs
{
    public class DtoCliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorAPagar { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
