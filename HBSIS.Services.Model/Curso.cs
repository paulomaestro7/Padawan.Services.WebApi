using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Services.Model
{
    public class Curso
    {
        public string nome { get; set; }
        public List<Materia> materia { get; set; }
    }
}
