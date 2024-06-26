using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FloripaSurfClub.Repositories
{
    internal class ReposCliente
    {
        internal static Cliente Buscar(Guid pId)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Clientes
                           .Include(a => a.UsuarioSistema)
                           .FirstOrDefault(a => a.Id == pId);
            }
        }

        internal static List<Cliente> Listar()
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                return ctx.Clientes
                           .Include(a => a.UsuarioSistema)
                           .ToList();
            }
        }

        internal static bool Criar(Cliente pCliente)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                ctx.Clientes.Add(pCliente);
                return ctx.SaveChanges() > 0;
            }
        }

        internal static bool Atualizar(Cliente pCliente)
        {
            using (var ctx = new FloripaSurfClubContext())
            {
                var clienteExistente = ctx.Clientes
                                          .Include(c => c.UsuarioSistema)
                                          .FirstOrDefault(c => c.Id == pCliente.Id);

                if (clienteExistente != null)
                {
                    clienteExistente.Nome = pCliente.Nome;
                    clienteExistente.ValorAPagar = pCliente.ValorAPagar;
                    clienteExistente.Telefone = pCliente.Telefone;
                    clienteExistente.Email = pCliente.Email;

                    if (clienteExistente.UsuarioSistema != null)
                    {
                        clienteExistente.UsuarioSistema.Nome = pCliente.Nome;
                        clienteExistente.UsuarioSistema.Email = pCliente.Email;
                        clienteExistente.UsuarioSistema.PhoneNumber = pCliente.Telefone;
                    }

                    ctx.Entry(clienteExistente).State = EntityState.Modified;
                    return ctx.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}
