using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioGestion.Model;
using ServicioGestion;
using ServicioGestionTestSpace.ServiceReference1;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace ServicioGestionTestSpace.ServiceReference1
{
    [TestClass]
    public class ServicioGestionTest
    {

        ServicioGestionClient proxy = new ServicioGestionClient();

        /******************************* TEST ADD *******************************************

        [TestMethod]
        public void AddUsuarioTest()
        {

        }

        [TestMethod]
        public void AddAccionComercialTest()
        {

        }

        /*[TestMethod]
        public void AddTipoAccionTest()
        {
            TipoDeAccionData tipo = null;
            Assert.IsFalse(AddTipoAccion(tipo));

            tipo = new TipoDeAccionData() { idTipoAccion = 0, descripcion = "Tipo de acción de prueba 1" };
            Assert.IsTrue(AddTipoAccion(tipo));

            tipo = new TipoDeAccionData() { idTipoAccion = 0, descripcion = "Tipo de acción de prueba 2" };
            Assert.IsTrue(AddTipoAccion(tipo));

            tipo = new TipoDeAccionData() { idTipoAccion = -1, descripcion = "Tipo de acción de prueba 3" };
            Assert.IsTrue(AddTipoAccion(tipo));

            tipo = new TipoDeAccionData() { idTipoAccion = 1, descripcion = "Tipo de acción de prueba 4" };
            Assert.IsTrue(AddTipoAccion(tipo));

            tipo = new TipoDeAccionData() { descripcion = "Tipo de acción de prueba 5" };
            Assert.IsTrue(AddTipoAccion(tipo));
        }

        public void AddEstadoAccionTest()
        {

        }*

        [TestMethod]
        public void AddEmpresaTest()
        {

        }

        [TestMethod]
        public void AddSectorTest()
        {

        }*/

        [TestMethod]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\tablets\\Source\\Repos\\Company\\GestionEmpresas\\ServicioGestion", "/")]
        [UrlToTest("http://localhost:2231/WebForm1.aspx")]
        public void AddTelefonoTest()
        {
            //addTelefono(null, null, null)
            TelefonoData telefono = null;
            EmpresaData empresa = null;
            ContactoData contacto = null;
            Assert.IsFalse(proxy.AddTelefono(telefono, empresa, contacto));

            //addTelefono(telefono, null, null)
            telefono = new TelefonoData() { numero = "numero de prueba 1" };
            Assert.IsFalse(proxy.AddTelefono(telefono, empresa, contacto));

            //addTelefono(null, empresa, null)
            telefono = null;
            empresa = new EmpresaData() { cif = "cif1", nombreComercial = "nombre1", razonSocial = "razon1", sector = "Informatica", web = "web1" };
            Assert.IsFalse(proxy.AddTelefono(telefono, empresa, contacto));

            //addTelefono(null, null, contacto)
            telefono = null;
            empresa = null;
            contacto = new ContactoData() { idEmpresa = 1, nif = "nif1", nombre = "nombre1" };
            Assert.IsFalse(proxy.AddTelefono(telefono, empresa, contacto));

            //addTelefono(telefono, null, contacto)
            telefono = new TelefonoData() { numero = "numero de prueba 2" };
            Assert.IsFalse(proxy.AddTelefono(telefono, empresa, contacto));


        }

        /// <summary>
        /// Método que hace pruebas sobre el método de addEmail.
        /// </summary>
        [TestMethod]
        public void AddEmailTest()
        {
            EmpresaData emp=new EmpresaData();
            EmpresaData[] lista=proxy.getAllEmpresa();
            EmailData email = new EmailData();
            ContactoData contacto = new ContactoData();

            EmailData[] listaEmpAdd = proxy.getAllEmail();
            int numeroEmpAdd=listaEmpAdd.Length;
            //Añado un email de ejemplo
            email.Correo = "ejemplo@gmail.com";
            email.EmailID=proxy.addEmail(email.Correo, lista[0], contacto);
            //Compruebo el numero de elementos despues de insertar.
            listaEmpAdd = proxy.getAllEmail();
            int numeroEmpAddAfter = listaEmpAdd.Length;
            //Se comprueba que se haya insertado y luego que se haya eliminado de la base de datos.
            Assert.AreNotEqual(-1, email.EmailID);
            //el numero de elementos debe haber aumentado en uno.
            Assert.AreEqual(numeroEmpAdd + 1, numeroEmpAddAfter);


            EmailData[] listaEmp = proxy.getAllEmail();
            //Se obtienen el numero de elementos antes de eliminar un registro
            int numeroEmp=listaEmp.Length;
            Assert.IsTrue(proxy.deleteEmail(email.EmailID));
            //Se obtiene el numero de elementos despues de eliminar un registro
            listaEmp = proxy.getAllEmail();
            int numeroEmpDelete=listaEmp.Length;
            //Se comprueba que haya un elemento menos después de eliminar.
            Assert.AreEqual(numeroEmp - 1, numeroEmpDelete);


            //Esta prueba no añade ningún registro, ya que los dos ultimos parámetros son null.
            email.Correo = "ejemplo2@gmail.com";
            email.EmailID = proxy.addEmail(email.Correo,null,null);
            Assert.AreEqual(-1, email.EmailID);

        }

        /*
        [TestMethod]
        public void AddDireccionTest()
        {

        }

        [TestMethod]
        public void AddContactoTest()
        {

        }

        /******************************* TEST EDIT *******************************************

        [TestMethod]
        public void EditUsuarioTest()
        {

        }

        [TestMethod]
        public void EditAccionComercialTest()
        {

        }

        [TestMethod]
        public void EditTipoAccionTest()
        {

        }

        public void EditEstadoAccionTest()
        {

        }

        [TestMethod]
        public void EditEmpresaTest()
        {

        }

        [TestMethod]
        public void EditSectorTest()
        {

        }

        [TestMethod]
        public void EditTelefonoTest()
        {

        }

        [TestMethod]
        public void EditEmailTest()
        {

        }

        [TestMethod]
        public void EditDireccionTest()
        {

        }

        [TestMethod]
        public void EditContactoTest()
        {

        }

        /******************************* TEST DELETE *******************************************

        [TestMethod]
        public void DeleteUsuarioTest()
        {

        }

        [TestMethod]
        public void DeleteAccionComercialTest()
        {

        }

        [TestMethod]
        public void DeleteTipoAccionTest()
        {

        }

        public void DeleteEstadoAccionTest()
        {

        }

        [TestMethod]
        public void DeleteEmpresaTest()
        {

        }

        [TestMethod]
        public void DeleteSectorTest()
        {

        }

        [TestMethod]
        public void DeleteTelefonoTest()
        {

        }

        [TestMethod]
        public void DeleteEmailTest()
        {

        }

        [TestMethod]
        public void DeleteDireccionTest()
        {

        }

        [TestMethod]
        public void DeleteContactoTest()
        {

        }

        /******************************* TEST GET *******************************************

        [TestMethod]
        public void GetUsuarioTest()
        {

        }

        [TestMethod]
        public void GetAccionComercialTest()
        {

        }

        [TestMethod]
        public void GetTipoAccionTest()
        {

        }

        public void GetEstadoAccionTest()
        {

        }

        [TestMethod]
        public void GetEmpresaTest()
        {

        }

        [TestMethod]
        public void GetSectorTest()
        {

        }

        [TestMethod]
        public void GetTelefonoTest()
        {

        }

        [TestMethod]
        public void GetEmailTest()
        {

        }

        [TestMethod]
        public void GetDireccionTest()
        {

        }

        [TestMethod]
        public void GetContactoTest()
        {

        }

        /******************************* TEST GETALL *******************************************

        [TestMethod]
        public void GetAllUsuarioTest()
        {

        }

        [TestMethod]
        public void GetAllAccionComercialTest()
        {

        }

        [TestMethod]
        public void GetAllTipoAccionTest()
        {

        }

        public void GetAllEstadoAccionTest()
        {

        }

        [TestMethod]
        public void GetAllEmpresaTest()
        {

        }

        [TestMethod]
        public void GetAllSectorTest()
        {

        }

        [TestMethod]
        public void GetAllTelefonoTest()
        {

        }

        [TestMethod]
        public void GetAllEmailTest()
        {

        }

        [TestMethod]
        public void GetAllDireccionTest()
        {

        }

        [TestMethod]
        public void GetAllContactoTest()
        {

        }*/

    }
}
