using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using Microsoft.EntityFrameworkCore;

internal class ReposProfessor
{
    internal static bool Criar(Professor pProfessor)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            ctx.Professores.Add(pProfessor);
            return ctx.SaveChanges() > 0;
        }
    }

    internal static Professor Buscar(Guid pId)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            return ctx.Professores
                      .Include(p => p.UsuarioSistema)  // Inclui o UsuarioSistema
                      .FirstOrDefault(x => x.Id == pId);
        }
    }

    internal static List<Professor> Listar()
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            return ctx.Professores
                      .Include(p => p.UsuarioSistema)  // Inclui o UsuarioSistema
                      .ToList();
        }
    }

    internal static bool Atualizar(Professor pProfessor)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            var professorExistente = ctx.Professores
                                        .Include(p => p.UsuarioSistema)
                                        .FirstOrDefault(p => p.Id == pProfessor.Id);

            if (professorExistente != null)
            {
                professorExistente.UsuarioSistema.Nome = pProfessor.Nome;

                professorExistente.ValorAReceber = pProfessor.ValorAReceber;
                professorExistente.Nome = pProfessor.Nome;

                ctx.Entry(professorExistente.UsuarioSistema).State = EntityState.Modified;
                ctx.Entry(professorExistente).State = EntityState.Modified;
                return ctx.SaveChanges() > 0;
            }

            return false;
        }
    }

    internal static bool Remover(Guid pId)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            var professor = ctx.Professores.FirstOrDefault(x => x.Id == pId);
            if (professor != null)
            {
                ctx.Professores.Remove(professor);
                return ctx.SaveChanges() > 0;
            }

            return false;
        }
    }

    internal static bool EstaDisponivel(Professor professor, DateTime dataHora)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            // Ignorar milissegundos na comparação de data e hora
            var aulaExistente = ctx.Aulas
                .Any(a => a.ProfessorId == professor.Id &&
                          a.DataInicio.Year == dataHora.Year &&
                          a.DataInicio.Month == dataHora.Month &&
                          a.DataInicio.Day == dataHora.Day &&
                          a.DataInicio.Hour == dataHora.Hour &&
                          a.DataInicio.Minute == dataHora.Minute);

            return !aulaExistente;
        }
    }
}
