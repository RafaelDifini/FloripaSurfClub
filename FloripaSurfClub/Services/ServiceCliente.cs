using FloripaSurfClub.Models;
using FloripaSurfClub.Repositories;
using System;
using System.Collections.Generic;

namespace FloripaSurfClub.Services
{
    public static class ServiceCliente
    {
        public static Cliente Buscar(Guid id)
        {
            return ReposCliente.Buscar(id);
        }

        public static List<Cliente> Listar()
        {
            return ReposCliente.Listar();
        }

        public static bool Criar(Cliente cliente)
        {
            return ReposCliente.Criar(cliente);
        }

        public static bool Atualizar(Cliente cliente)
        {
            return ReposCliente.Atualizar(cliente);
        }
    }
}
