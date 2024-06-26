using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Repositories
{
    internal class ReposAula
    {
        internal static bool Agendar(Aula pAula)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var professorDisponivel = ReposProfessor.EstaDisponivel(pAula.Professor, pAula.DataInicio);

                if (!professorDisponivel)
                {
                    return false;
                }
                ctx.Entry(pAula).State = EntityState.Added;
                return ctx.SaveChanges() > 0;
            }
        }

        internal static bool Concluir(Aula pAula)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                ctx.Entry(pAula).State = EntityState.Modified;

                var professor = ctx.Professores.Find(pAula.ProfessorId);
                if (professor != null)
                {
                    professor.ValorAReceber += pAula.Valor * 0.5m;
                    ctx.Entry(professor).State = EntityState.Modified;
                }

                return ctx.SaveChanges() > 0;
            }
        }

        internal static Aula Buscar(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Aulas.Where(x => x.Id == pId).FirstOrDefault();
            }
        }
    }
}