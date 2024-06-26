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
    internal class ReposCaixa
    {
        internal static bool AbrirCaixa(Caixa pCaixa)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                ctx.Entry(pCaixa).State = EntityState.Added;
                return ctx.SaveChanges() > 0;
            }
        }

        internal static bool Atualizar(Caixa pCaixa)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                ctx.Entry(pCaixa).State = EntityState.Modified;
                return ctx.SaveChanges() > 0;
            }
        }

        internal static Caixa Buscar(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Caixa.FirstOrDefault(c => c.Id == pId); 
            }
        }
    }
}
