using System.ComponentModel.DataAnnotations;

namespace FloripaSurfClubWeb.Models.Account
{
    public class LoginViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string? Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool LembrarMe { get; set; }


    }
}
