using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Services.DataBase.Model
{
    public class PessoaFisicaModel
    {
        public PessoaFisicaModel()
        {
            Dependente = new HashSet<DependenteModel>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        
        public virtual ICollection<DependenteModel> Dependente { get; set; }
    }
}
