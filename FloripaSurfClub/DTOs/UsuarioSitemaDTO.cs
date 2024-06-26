using FloripaSurfClub.Enums;

namespace FloripaSurfClub.DTOs
{
    public class UsuarioSistemaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Password { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }
    }
}
