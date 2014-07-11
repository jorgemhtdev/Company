using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioGestion.Model;
using ServicioGestion;

namespace ServicioGestionTest
{
    [TestClass]
    public class ServicioGestionTest
    {

        /******************************* TEST ADD *******************************************/

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

        }*/

        [TestMethod]
        public void AddEmpresaTest()
        {

        }

        [TestMethod]
        public void AddSectorTest()
        {

        }

        [TestMethod]
        public void AddTelefonoTest()
        {
            //addTelefono(null, null, null)
            TelefonoData telefono = null;
            EmpresaData empresa = null;
            ContactoData contacto = null;
            Assert.IsFalse(AddTelefono(telefono, empresa, contacto));

            //addTelefono(telefono, null, null)
            telefono = new TelefonoData() { numero = "numero de prueba 1" };
            Assert.IsFalse(AddTelefono(telefono, empresa, contacto));

            //addTelefono(null, empresa, null)
            telefono = null;
            empresa = new EmpresaData() { cif = "cif1", nombreComercial = "nombre1", razonSocial = "razon1", sector = 1, web = "web1" };
            Assert.IsFalse(AddTelefono(telefono, empresa, contacto));

            //addTelefono(null, null, contacto)
            telefono = null;
            empresa = null;
            contacto = new ContactoData() { idEmpresa = 1, nif = "nif1", nombre = "nombre1" };
            Assert.IsFalse(AddTelefono(telefono, empresa, contacto));

            //addTelefono(telefono, null, contacto)
            telefono = new TelefonoData() { numero = "numero de prueba 2" };
            Assert.IsFalse(AddTelefono(telefono, empresa, contacto));


        }

        [TestMethod]
        public void AddEmailTest()
        {

        }

        [TestMethod]
        public void AddDireccionTest()
        {

        }

        [TestMethod]
        public void AddContactoTest()
        {

        }

        /******************************* TEST EDIT *******************************************/

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

        /******************************* TEST DELETE *******************************************/

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

        /******************************* TEST GET *******************************************/

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

        /******************************* TEST GETALL *******************************************/

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

        }

    }
}
