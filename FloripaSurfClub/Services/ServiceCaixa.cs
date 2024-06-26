using FloripaSurfClub.Models;
using FloripaSurfClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Services
{
    public class ServiceCaixa
    {
        public static Caixa Buscar(Guid pId)
        {
            return ReposCaixa.Buscar(pId);
        }
        public static bool AbrirCaixa(Caixa pCaixa)
        {
            return ReposCaixa.AbrirCaixa(pCaixa);
        }

        public static bool Atualizar(Caixa pCaixa)
        {
            return ReposCaixa.Atualizar(pCaixa);
        }
    }
}
