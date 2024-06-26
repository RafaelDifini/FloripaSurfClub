using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return ctx.Alunos
                           .Include(a => a.UsuarioSistema)
                           .Include(a => a.Aulas)
                           .FirstOrDefault(a => a.Id == pId);
            }
        }

        internal static List<Aluno> Listar()
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Alunos
                           .Include(a => a.UsuarioSistema)
                           .Include(a => a.Aulas)
                           .ToList();
            }
        }

        internal static bool Atualizar(Aluno pAluno)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var alunoExistente = ctx.Alunos
                                         .Include(a => a.UsuarioSistema)
                                         .Include(a => a.Aulas)
                                         .FirstOrDefault(a => a.Id == pAluno.Id);

                if (alunoExistente != null)
                {
                    alunoExistente.Nome = pAluno.Nome;
                    alunoExistente.Peso = pAluno.Peso;
                    alunoExistente.Altura = pAluno.Altura;
                    alunoExistente.Nacionalidade = pAluno.Nacionalidade;
                    alunoExistente.Nivel = pAluno.Nivel;

                    alunoExistente.UsuarioSistema.Nome = pAluno.Nome;

                    ctx.Entry(alunoExistente).State = EntityState.Modified;
                    return ctx.SaveChanges() > 0;
                }

                return false;
            }
        }

        internal static bool Remover(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var aluno = ctx.Alunos.FirstOrDefault(x => x.Id == pId);
                if (aluno != null)
                {
                    ctx.Alunos.Remove(aluno);
                    return ctx.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}
