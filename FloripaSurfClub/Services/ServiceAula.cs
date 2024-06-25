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
    }
}
