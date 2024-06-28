using FloripaSurfClub.Enums;


namespace FloripaSurfClub.DTOs
{
    public class DtoAluno : DtoUsuarioSistema
    {
        public decimal Peso { get; set; }
        public int Altura { get; set; }
        public string Nacionalidade { get; set; }
        public ENivel Nivel { get; set; }
    }
}

