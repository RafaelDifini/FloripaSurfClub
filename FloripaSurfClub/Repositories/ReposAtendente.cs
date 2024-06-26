using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using Microsoft.EntityFrameworkCore;

internal class ReposAtendente
{
    internal static bool Criar(Atendente pAtendente)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            ctx.Atendentes.Add(pAtendente);
            return ctx.SaveChanges() > 0;
        }
    }

    internal static Atendente Buscar(Guid pId)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            return ctx.Atendentes
                      .Include(a => a.UsuarioSistema)  
                      .FirstOrDefault(x => x.Id == pId);
        }
    }

    internal static List<Atendente> Listar()
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            return ctx.Atendentes
                      .Include(a => a.UsuarioSistema)  
                      .ToList();
        }
    }

    internal static bool Atualizar(Atendente pAtendente)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            var atendenteExistente = ctx.Atendentes
                                        .Include(a => a.UsuarioSistema)
                                        .FirstOrDefault(a => a.Id == pAtendente.Id);

            if (atendenteExistente != null)
            {
                atendenteExistente.Nome = pAtendente.Nome;
                atendenteExistente.ValorAReceber = pAtendente.ValorAReceber;

                atendenteExistente.UsuarioSistema.Nome = pAtendente.Nome;
                atendenteExistente.UsuarioSistema.Email = pAtendente.UsuarioSistema.Email;
                atendenteExistente.UsuarioSistema.PhoneNumber = pAtendente.UsuarioSistema.PhoneNumber;

                ctx.Entry(atendenteExistente).State = EntityState.Modified;
                ctx.Entry(atendenteExistente.UsuarioSistema).State = EntityState.Modified;
                return ctx.SaveChanges() > 0;
            }

            return false;
        }
    }

    internal static bool Remover(Guid pId)
    {
        using (var ctx = new FloripaSurfClubContext())
        {
            var atendente = ctx.Atendentes.FirstOrDefault(x => x.Id == pId);
            if (atendente != null)
            {
                ctx.Atendentes.Remove(atendente);
                return ctx.SaveChanges() > 0;
            }

            return false;
        }
    }
}
