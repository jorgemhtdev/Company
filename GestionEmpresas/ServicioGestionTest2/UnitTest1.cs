using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioGestionTest2.ServiceReference1;

namespace ServicioGestionTest2
{
     
    [TestClass]
    public class UnitTest1
    {

        ServiceReference1.ServicioGestionClient proxy = new ServicioGestionClient();
        [TestMethod]
        
        public void TestMethod1()
        {
            EmpresaData [] lista=proxy.getAllEmpresa();
            Assert.IsNotNull(lista);
        }
    }
}
