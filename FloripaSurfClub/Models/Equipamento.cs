﻿using FloripaSurfClub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloripaSurfClub.Models
{
    public class Equipamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoEquipamento Tipo { get; set; }

    }
}
