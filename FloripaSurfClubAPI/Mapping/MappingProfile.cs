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

            CreateMap<Aluno, DtoAluno>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UsuarioSistema.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.UsuarioSistema.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.Ignore()) 
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.UsuarioSistema.TipoUsuario))
                .ReverseMap();

            CreateMap<Professor, DtoProfessor>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UsuarioSistema.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.UsuarioSistema.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.Ignore()) 
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.UsuarioSistema.TipoUsuario))
                .ReverseMap();

            CreateMap<Atendente, DtoAtendente>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UsuarioSistema.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.UsuarioSistema.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.Ignore()) 
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.UsuarioSistema.TipoUsuario))
                .ReverseMap();

            CreateMap<Aula, DtoAula>()
                .ForMember(dest => dest.AlunoIds, opt => opt.MapFrom(src => src.Alunos.Select(a => a.Id).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.Alunos, opt => opt.Ignore())
                .AfterMap((dto, aula, ctx) =>
                {
                    if (dto.AlunoIds != null)
                    {
                        aula.Alunos = dto.AlunoIds.Select(id => new Aluno { Id = id }).ToList();
                    }
                });

            CreateMap<Cliente, DtoCliente>().ReverseMap();
        }
    }
}
