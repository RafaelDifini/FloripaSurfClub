﻿using FloripaSurfClub.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Models
{
    public class UsuarioSistema : IdentityUser<Guid>
    {
        public string Nome { get; set; }

        public  ETipoUsuario TipoUsuario { get; set; }
    }
}
