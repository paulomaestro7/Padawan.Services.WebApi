using HBSIS.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HBSIS.Services.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidaSenha_Ok()
        {
            var result = new Funcao().ValidaLogin("MeuUsuario", "MinhaSenha");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidaSenha_Error()
        {
            var result = new Funcao().ValidaLogin("MeuUsuariasasasaso", "MinhaSenha");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidaUsuario_Ok()
        {
            var result = new Funcao().ValidaLogin("MeuUsuario", "MinhaSenha");
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void Validausuairo_Error()
        {
            var result = new Funcao().ValidaLogin("MeuUsuariao", "MinhaSenhaaaa");
            Assert.IsFalse(result);
        }

    }
}
