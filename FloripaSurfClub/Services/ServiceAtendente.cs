using FloripaSurfClub.Models;
using FloripaSurfClub.Repositories;
using System;
using System.Collections.Generic;

namespace FloripaSurfClub.Services
{
    public class ServiceAtendente
    {
        public static bool Criar(Atendente pAtendente)
        {
            return ReposAtendente.Criar(pAtendente);
        }

        public static Atendente Buscar(Guid pId)
        {
            return ReposAtendente.Buscar(pId);
        }

        public static List<Atendente> Listar()
        {
            return ReposAtendente.Listar();
        }

        public static bool Atualizar(Atendente pAtendente)
        {
            return ReposAtendente.Atualizar(pAtendente);
        }

        public static bool Remover(Guid pId)
        {
            return ReposAtendente.Remover(pId);
        }
    }
}
