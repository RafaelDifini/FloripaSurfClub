using AutoMapper;
using FloripaSurfClub.DTOs;
using FloripaSurfClub.Models;

namespace FloripaSurfClubAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioSistema, UsuarioSistemaDTO>().ReverseMap();

            CreateMap<Aluno, AlunoDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UsuarioSistema.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.UsuarioSistema.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.Ignore()) 
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.UsuarioSistema.TipoUsuario))
                .ReverseMap();

            CreateMap<Professor, ProfessorDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UsuarioSistema.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.UsuarioSistema.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.Ignore()) 
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.UsuarioSistema.TipoUsuario))
                .ReverseMap();

            CreateMap<Atendente, AtendenteDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UsuarioSistema.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.UsuarioSistema.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.Ignore()) 
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.UsuarioSistema.TipoUsuario))
                .ReverseMap();
        }
    }
}
