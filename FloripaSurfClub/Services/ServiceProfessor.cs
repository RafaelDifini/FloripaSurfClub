using FloripaSurfClub.Models;
using FloripaSurfClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Services
{
    public class ServiceProfessor
    {
        public static bool Criar(Professor pProfessor)
        {
            return ReposProfessor.Criar(pProfessor);
        }

        public static Professor Buscar(Guid pId)
        {
            return ReposProfessor.Buscar(pId);
        }
        public static List<Professor> Listar()
        {
            return ReposProfessor.Listar();
        }
        public static bool Atualizar(Professor pProfessor)
        {
            return ReposProfessor.Atualizar(pProfessor);
        }
        public static bool Remover(Guid pId)
        {
            return ReposProfessor.Remover(pId);
        }

    }
}
