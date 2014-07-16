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
        public void AddTelefonoTest()
        {
            int id;
            int registros;
            
            //addTelefono(null, null, null)
            TelefonoData telefono = null;
            EmpresaData empresa = null;
            ContactoData contacto = null;
            registros = proxy.GetAllTelefonos().Length;
            Assert.AreEqual(-1, proxy.AddTelefono(telefono, empresa, contacto));
            Assert.IsTrue(registros == proxy.GetAllTelefonos().Length);

            //addTelefono(telefono, null, null)
            telefono = new TelefonoData() { numero = "numero de prueba 1" };
            registros = proxy.GetAllTelefonos().Length;
            Assert.AreEqual(-1, proxy.AddTelefono(telefono, empresa, contacto));
            Assert.IsTrue(registros == proxy.GetAllTelefonos().Length);

            //addTelefono(null, empresa, null)
            telefono = null;
            empresa = new EmpresaData() { EmpresaID = 1, cif = "cif1", nombreComercial = "nombre1", razonSocial = "razon1", sector = "sector1", web = "web1" };
            registros = proxy.GetAllTelefonos().Length;
            Assert.AreEqual(-1, proxy.AddTelefono(telefono, empresa, contacto));
            Assert.IsTrue(registros == proxy.GetAllTelefonos().Length);

            //addTelefono(null, null, contacto)
            telefono = null;
            empresa = null;
            contacto = new ContactoData() { idContacto = 2, idEmpresa = 1, nif = "nif1", nombre = "nombre1" };
            registros = proxy.GetAllTelefonos().Length;
            Assert.AreEqual(-1, proxy.AddTelefono(telefono, empresa, contacto));
            Assert.IsTrue(registros == proxy.GetAllTelefonos().Length);

            //addTelefono(telefono, null, contacto)
            telefono = new TelefonoData() { numero = "prueba 1" };
            registros = proxy.GetAllTelefonos().Length;
            id = proxy.AddTelefono(telefono, empresa, contacto);
            Assert.AreNotEqual(-1, id);
            Assert.IsTrue(registros + 1 == proxy.GetAllTelefonos().Length);
            proxy.DeleteTelefono(id);

            //addTelefono(telefono, empresa, null)
            telefono = new TelefonoData() { numero = "prueba 2" };
            empresa = new EmpresaData() { EmpresaID = 1, cif = "cif1", nombreComercial = "nombre1", razonSocial = "razon1", sector = "sector1", web = "web1" };
            contacto = null;
            registros = proxy.GetAllTelefonos().Length;
            id = proxy.AddTelefono(telefono, empresa, contacto);
            Assert.AreNotEqual(-1, id);
            Assert.IsTrue(registros + 1 == proxy.GetAllTelefonos().Length);
            proxy.DeleteTelefono(id);

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
        */
        [TestMethod]
        public void EditTelefonoTest()
        {
            Assert.IsTrue(proxy.EditTelefono(null) == -1);
            
            TelefonoData tOriginal = new TelefonoData() { numero = "prueba" };
            int nuevo = proxy.AddTelefono(tOriginal, new EmpresaData() { EmpresaID = 1 }, null);
            Assert.IsTrue(proxy.EditTelefono(new TelefonoData() { idTelefono = nuevo, numero = "cambiado" }) != -1);
            Assert.IsTrue(proxy.GetIdTelefono(nuevo).numero == "cambiado");
            proxy.DeleteTelefono(nuevo);
        }
        /*
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
        */
        [TestMethod]
        public void DeleteTelefonoTest()
        {
            int nuevo = proxy.AddTelefono(new TelefonoData() { numero = "prueba1" }, new EmpresaData() { EmpresaID = 1 }, null);
            int registros = proxy.GetAllTelefonos().Length;
            Assert.IsTrue(proxy.DeleteTelefono(nuevo));
            Assert.IsTrue(registros - 1 == proxy.GetAllTelefonos().Length);

        }
        /*
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
        */
        [TestMethod]
        public void GetTelefonoTest()
        {
            TelefonoData t = new TelefonoData() { numero = "prueba" };
            int nuevo = proxy.AddTelefono(t, new EmpresaData() { EmpresaID = 1 }, null);
            Assert.IsTrue(proxy.GetIdTelefono(nuevo).numero == t.numero);
            proxy.DeleteTelefono(nuevo);
        }
        /*
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
        */
        [TestMethod]
        public void GetAllTelefonoTest()
        {
            int registros = proxy.GetAllTelefonos().Length;
            int nuevo = proxy.AddTelefono(new TelefonoData() { numero = "prueba" }, new EmpresaData() { EmpresaID = 1 }, null);

            Assert.IsTrue(registros + 1 == proxy.GetAllTelefonos().Length);
            proxy.DeleteTelefono(nuevo);
        }
        /*
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
