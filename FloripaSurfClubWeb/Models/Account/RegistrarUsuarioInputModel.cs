using FloripaSurfClub.Enums;
using System.ComponentModel.DataAnnotations;

namespace FloripaSurfClubWeb.Models.Account
{
    public class RegistrarUsuarioInputModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string? ConfirmaSenha { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }
        public decimal? Peso { get; set; }
        public int? Altura { get; set; }
        public string? Nacionalidade { get; set; }
        public ENivel? Nivel { get; set; }
    }
}
