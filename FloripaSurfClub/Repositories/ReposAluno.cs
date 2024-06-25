using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Repositories
{
    internal class ReposAluno
    {
        internal static bool Criar(Aluno pAluno)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                ctx.Alunos.Add(pAluno);
                return ctx.SaveChanges() > 0;
            }
        }

        internal static Aluno Buscar(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Alunos.Where(x => x.Id == pId).FirstOrDefault();
            }
        }

        internal static List<Aluno> Listar()
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Alunos.ToList();
            }
        }

        internal static bool Atualizar(Aluno pAluno)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                ctx.Alunos.Attach(pAluno);
                ctx.Alunos.Update(pAluno);
                return ctx.SaveChanges() > 0;
            }
        }

        internal static bool Remover(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var aluno = ctx.Alunos.Where(x => x.Id == pId).FirstOrDefault();
                ctx.Alunos.Remove(aluno);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
