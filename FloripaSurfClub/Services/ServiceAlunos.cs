using FloripaSurfClub.Models;
using FloripaSurfClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Services
{
    public class ServiceAlunos
    {
        public static bool Criar(Aluno pAluno)
        {
            return ReposAluno.Criar(pAluno);
        }

        public static Aluno Buscar(Guid pId)
        {
            return ReposAluno.Buscar(pId);
        }
        public static List<Aluno> Listar()
        {
            return ReposAluno.Listar();
        }
        public static bool Atualizar(Aluno pAluno)
        {
            return ReposAluno.Atualizar(pAluno);
        }
        public static bool Remover(Guid pId)
        {
            return ReposAluno.Remover(pId);
        }
    }
}
