using FloripaSurfClub.Models;
using FloripaSurfClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Services
{
    public class ServiceAula
    {
        public static bool Agendar(Aula pAula)
        {
            return ReposAula.Agendar(pAula);
        }

        public static Aula Buscar(Guid pId)
        {
            return ReposAula.Buscar(pId);
        }
        public static List<Aula> Listar()
        {
            return ReposAula.Listar();
        }

        public static bool Remover(Guid pId)
        {
            return ReposAula.Remover(pId);
        }

        public static bool Atualizar(Aula pAula)
        {
            return ReposAula.Atualizar(pAula);
        }
    }
}
