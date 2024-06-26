using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Repositories
{
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
                return ctx.Professores.Where(x => x.Id == pId).FirstOrDefault();
            }
        }

        internal static List<Professor> Listar()
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Professores.ToList();
            }
        }

        internal static bool Atualizar(Professor pProfessor)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                ctx.Professores.Attach(pProfessor);
                ctx.Professores.Update(pProfessor);
                return ctx.SaveChanges() > 0;
            }
        }

        internal static bool Remover(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var professor = ctx.Professores.Where(x => x.Id == pId).FirstOrDefault();
                ctx.Professores.Remove(professor);
                return ctx.SaveChanges() > 0;
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
}
