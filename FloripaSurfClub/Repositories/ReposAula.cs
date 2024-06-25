using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
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
                    // Professor já tem uma aula agendada nesse horário
                    return false;
                }

                ctx.Aulas.Add(pAula);

                var professor = ctx.Professores.FirstOrDefault(p => p.Id == pAula.Professor.Id);
                if (professor != null)
                {
                    professor.ValoresAReceber += pAula.Valor * 0.5m;
                    ctx.Professores.Update(professor);
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