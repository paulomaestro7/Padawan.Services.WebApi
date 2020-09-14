using System;

namespace HBSIS.Services.Model
{
    public class PessoaFisica
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public bool Ativo { get; set; }
    }
}
