﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Services.Model
{
   public  class Departamento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
