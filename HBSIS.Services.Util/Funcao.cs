using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Services.Util
{
    public class Funcao
    {
        public string Usuario = "MeuUsuario";
        public string Senha = "MinhaSenha";

        public bool ValidaLogin(string usuario, string senha)
        {
            if (ValidaSenha(senha))
            {
                if (!ValidaUsuario(usuario))
                    return false;
            }
            else
                return false;

            return true;
        }
        private bool ValidaUsuario(string usuario)
        {
            if (usuario != Usuario)
                return false;
            return true;
        }
        private bool ValidaSenha(string senha)
        {
            if (senha != Senha)
                return false;

            return true;
        }

    }
}
