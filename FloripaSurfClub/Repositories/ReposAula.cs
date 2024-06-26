using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

                ctx.Entry(pAula.Professor).State = EntityState.Unchanged;

                foreach (var aluno in pAula.Alunos)
                {
                    ctx.Entry(aluno).State = EntityState.Unchanged;
                }

                ctx.Aulas.Add(pAula);

                return ctx.SaveChanges() > 0;
            }
        }


        internal static Aula Buscar(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Aulas
                           .Include(a => a.Professor)
                           .Include(a => a.Alunos)
                           .FirstOrDefault(x => x.Id == pId);
            }
        }

        internal static List<Aula> Listar()
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Aulas
                           .Include(a => a.Professor)
                           .Include(a => a.Alunos)
                           .ToList();
            }
        }

        internal static bool Atualizar(Aula pAula)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var aulaExistente = ctx.Aulas
                                       .Include(a => a.Professor)
                                       .Include(a => a.Alunos)
                                       .FirstOrDefault(a => a.Id == pAula.Id);

                if (aulaExistente != null)
                {
                    aulaExistente.Concluida = pAula.Concluida;
                    aulaExistente.DataInicio = pAula.DataInicio;
                    aulaExistente.EhPacote = pAula.EhPacote;
                    aulaExistente.Valor = pAula.Valor;

                    aulaExistente.Alunos.Clear();
                    aulaExistente.Alunos.AddRange(pAula.Alunos.Select(aluno => new Aluno { Id = aluno.Id }));

                    if (pAula.Concluida)
                    {
                        Concluir(aulaExistente);
                    }

                    ctx.Entry(aulaExistente).State = EntityState.Modified;
                    return ctx.SaveChanges() > 0;
                }

                return false;
            }
        }

        internal static void Concluir(Aula pAula)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var professor = ctx.Professores.Find(pAula.ProfessorId);
                if (professor != null)
                {
                    professor.ValorAReceber += pAula.Valor * 0.5m;
                    ctx.Entry(professor).State = EntityState.Modified;
                }
            }
        }

        internal static bool Remover(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var aula = ctx.Aulas.FirstOrDefault(x => x.Id == pId);
                if (aula != null)
                {
                    ctx.Aulas.Remove(aula);
                    return ctx.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}
