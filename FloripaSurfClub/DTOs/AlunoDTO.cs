using FloripaSurfClub.Enums;


namespace FloripaSurfClub.DTOs
{
    public class AlunoDTO : UsuarioSistemaDTO
    {
        public decimal Peso { get; set; }
        public int Altura { get; set; }
        public string Nacionalidade { get; set; }
        public ENivel Nivel { get; set; }
    }
}

