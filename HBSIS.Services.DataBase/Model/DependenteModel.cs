using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Services.DataBase.Model
{
    public class DependenteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdPessoaFisica { get; set; }

        public virtual PessoaFisicaModel PessoaFisica { get; set; }
    }
}
