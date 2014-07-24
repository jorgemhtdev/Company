using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioGestion.Model;
using ServicioGestion;
using ServicioGestionTestSpace.ServiceReference1;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace ServicioGestionTestSpace.ServiceReference1
{
    [TestClass]
    public class ServicioGestionTest
    {

        ServicioGestionClient proxy = new ServicioGestionClient();

        /******************************* TEST ADD ********************************************/

        /// <summary>
        /// Método de prueba de añadir Usuario
        /// </summary>
        [TestMethod]
        public void AddUsuarioTest()
        {

            //Se añade un usuario correcto a la base de datos
            UsuarioData usuario=new UsuarioData();
            usuario.login="AddUsuario";
            usuario.nombre="Usuario";
            usuario.password = "111111";

            //Obtengo todos los usuarios de la base de datos
            UsuarioData[] usuarios = proxy.getAllUsuarios();
            //Se obtiene el numero de usuarios 
            int numUsuarios=usuarios.Length;
            //Se añade un usuario
            int idUsuario=proxy.addUsuario(usuario);

            Assert.AreEqual(numUsuarios + 1, proxy.getAllUsuarios().Length);
            Assert.IsTrue(proxy.deleteUsuario(idUsuario));

            //Se añade un usuario erróneo.
            //Se añade un usuario
            int idUsuario2 = proxy.addUsuario(null);
            Assert.AreEqual(-1, idUsuario2);

            //Se añade un usuario incorrecto a la base de datos
            UsuarioData usuario2 = new UsuarioData();
            usuario2.login = "";
            usuario2.nombre = "Usuario";
            usuario2.password = "111111";

            //Se añade un usuario
            int idUsuario3 = proxy.addUsuario(usuario2);

            //Se añade un usuario incorrecto a la base de datos
            UsuarioData usuario3 = new UsuarioData();
            usuario3.login = "Prueba";
            usuario3.nombre = "Usuario";
            usuario3.password = "";

            //Se añade un usuario
            int idUsuario4 = proxy.addUsuario(usuario3);

            
        }

        [TestMethod]
        public void AddAccionComercialTest()
        {
            EmpresaData[] listE = proxy.getAllEmpresa();
            UsuarioData[] listU = proxy.getAllUsuarios();
            TipoDeAccionData[] listTA = proxy.GetAllTipoAccion();
            EstadoAccion[] listEA = proxy.GetEstadoAccion();

            if (listE.Length == 0 || listU.Length == 0 || listTA.Length == 0 || listEA.Length == 0) return;

            AccionComercialData accion = new AccionComercialData()
            {
                descripcion = "prueba",
                comentarios = "esto es una prueba",
                fechaHora = new DateTime(2000, 12, 02),
                idEmpresa = listE[0].EmpresaID,
                idUsuario = listU[0].idUsuario,
                idEstadoAccion = listEA[0].idEstadoAccion,
                idTipoAccion = listTA[0].idTipoAccion
            };
            int nueva = proxy.addAccionComercial(accion);
            Assert.IsTrue(accion.descripcion == proxy.getAccionComercial(nueva).descripcion);
            proxy.deleteAccionComercial(nueva);
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

        }

        */
        [TestMethod]
        public void AddEmpresaTest()
        {
            EmpresaData[] empresas= proxy.getAllEmpresa();
            int numEmpresas=empresas.Length;

            //Insertamos una empresa válida, se comprueba que dicho método devuelva un indice distinto de -1 (-1 = error. No insertado)
            int idEmpresaNueva = proxy.addEmpresa("T7565466", "EmpresaTest nueva", "EmpresaTest nueva s.a.", "http://www.testNueva.es", 1);
            Assert.AreNotEqual(-1, idEmpresaNueva);

            //Se comprueba el numero de empresa. Debe aumentar en uno.
            Assert.AreEqual(numEmpresas + 1, proxy.getAllEmpresa().Length);

            proxy.deleteEmpresa(idEmpresaNueva);

            //Se comprueba el numero de empresa. De estar como al principio, ya que se ha eliminado la empresa recién insertada.
            Assert.AreEqual(numEmpresas, proxy.getAllEmpresa().Length);
           
            //Insertamos una empresa no válida. Debe devolver -1.
            int idEmpresaNueva2 = proxy.addEmpresa("", "", "EmpresaTest nueva s.a.", "http://www.testNueva.es", 1);
            Assert.AreEqual(-1, idEmpresaNueva2);

            //Insertamos una empresa no válida. Debe devolver -1.
            int idEmpresaNueva3 = proxy.addEmpresa("", "", "EmpresaTest nueva s.a.", "http://www.testNueva.es", 1);
            Assert.AreEqual(-1, idEmpresaNueva3);

            //Insertamos una empresa no válida. Debe devolver -1. Introducimos un sector erróneo, que no exista.
            int idEmpresaNueva4 = proxy.addEmpresa("A43656256", "Empresa No Valida", "EmpresaTest nueva No valida s.a.", "http://www.testNueva.es", 100);
            Assert.AreEqual(-1, idEmpresaNueva4);
        }

        /*
        [TestMethod]
        public void AddSectorTest()
        {

        }
        */
        [TestMethod]
        public void AddTelefonoTest()
        {
            int id;
            int registros;
            ContactoData[] listC = proxy.getAllContacto();
            EmpresaData[] listE = proxy.getAllEmpresa();

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
            if (listE.Length > 0)
            {
                empresa = listE[0];
                registros = proxy.GetAllTelefonos().Length;
                Assert.AreEqual(-1, proxy.AddTelefono(telefono, empresa, contacto));
                Assert.IsTrue(registros == proxy.GetAllTelefonos().Length);

                //addTelefono(telefono, empresa, null)
                telefono = new TelefonoData() { numero = "prueba 1" };
                registros = proxy.GetAllTelefonos().Length;
                id = proxy.AddTelefono(telefono, empresa, contacto);
                Assert.AreNotEqual(-1, id);
                Assert.IsTrue(registros + 1 == proxy.GetAllTelefonos().Length);
                proxy.DeleteTelefono(id);
            } 

            //addTelefono(null, null, contacto)
            telefono = null;
            empresa = null;
            if (listC.Length > 0)
            {
                contacto = listC[0];
                registros = proxy.GetAllTelefonos().Length;
                Assert.AreEqual(-1, proxy.AddTelefono(telefono, empresa, contacto));
                Assert.IsTrue(registros == proxy.GetAllTelefonos().Length);

                //addTelefono(telefono, null, contacto)
                telefono = new TelefonoData() { numero = "prueba 2" };
                registros = proxy.GetAllTelefonos().Length;
                id = proxy.AddTelefono(telefono, empresa, contacto);
                Assert.AreNotEqual(-1, id);
                Assert.IsTrue(registros + 1 == proxy.GetAllTelefonos().Length);
                proxy.DeleteTelefono(id);
            } 
        }

        /// <summary>
        /// Método que hace pruebas sobre el método de addEmail.
        /// También se comprueban las tablas intermedias. EmailContacto e EmailEmpresa
        /// </summary>
        [TestMethod]
        public void AddEmailTest()
        {
            
            EmpresaData emp=new EmpresaData();
            EmpresaData[] lista=proxy.getAllEmpresa();
            EmailData email = new EmailData();
            ContactoData contacto = new ContactoData();

            EmailData[] listaEmpAdd = proxy.getAllEmail();
            //Se comprueba la tabla intermedia
            EmailData[] listaMailEmpresa =proxy.getEmailEmpresa(lista[0].EmpresaID);

            int numeroEmpAdd=listaEmpAdd.Length;

            //Añado un email de ejemplo
            email.Correo = "ejemplo@gmail.com";
            email.EmailID=proxy.addEmail(email.Correo, lista[0], contacto);

            EmailData[] listaMailEmpresaAfter = proxy.getEmailEmpresa(lista[0].EmpresaID);
            //Se comprueba que la tabla intermedia se rellena correctamente
            Assert.AreEqual(listaMailEmpresa.Length+1, listaMailEmpresaAfter.Length);
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

        
        [TestMethod]
        public void AddDireccionTest()
        {
            int id;
            int registros;
            EmpresaData[] listE = proxy.getAllEmpresa();
            ContactoData[] listC = proxy.getAllContacto();

            //addDireccion(null, null, null)
            DireccionData direccion = null;
            EmpresaData empresa = null;
            ContactoData contacto = null;
            registros = proxy.GetAllDireccion().Length;
            Assert.AreEqual(-1, proxy.AddDireccion(direccion, empresa, contacto));
            Assert.IsTrue(registros == proxy.GetAllDireccion().Length);

            //addDireccion(Direccion, null, null)
            direccion = new DireccionData() { domicilio = "domprueba", poblacion = "pobprueba", codPostal = "cp0", provincia = "provprueba" };
            registros = proxy.GetAllDireccion().Length;
            Assert.AreEqual(-1, proxy.AddDireccion(direccion, empresa, contacto));
            Assert.IsTrue(registros == proxy.GetAllDireccion().Length);

            //addDireccion(null, empresa, null)
            direccion = null;
            if (listE.Length > 0)
            {
                empresa = listE[0];
                registros = proxy.GetAllDireccion().Length;
                Assert.AreEqual(-1, proxy.AddDireccion(direccion, empresa, contacto));
                Assert.IsTrue(registros == proxy.GetAllDireccion().Length);

                //addDireccion(Direccion, empresa, null)
                direccion = new DireccionData() { domicilio = "domprueba", poblacion = "pobprueba", codPostal = "cp0", provincia = "provprueba" };
                empresa = listE[0];
                contacto = null;
                registros = proxy.GetAllDireccion().Length;
                id = proxy.AddDireccion(direccion, empresa, contacto);
                Assert.AreNotEqual(-1, id);
                Assert.IsTrue(registros + 1 == proxy.GetAllDireccion().Length);
                proxy.DeleteDireccion(id);
            }

            //addDireccion(null, null, contacto)
            direccion = null;
            empresa = null;
            if (listC.Length > 0)
            {
                contacto = listC[0];
                registros = proxy.GetAllDireccion().Length;
                Assert.AreEqual(-1, proxy.AddDireccion(direccion, empresa, contacto));
                Assert.IsTrue(registros == proxy.GetAllDireccion().Length);

                //addDireccion(Direccion, null, contacto)
                direccion = new DireccionData() { domicilio = "domprueba", poblacion = "pobprueba", codPostal = "cp0", provincia = "provprueba" };
                registros = proxy.GetAllDireccion().Length;
                id = proxy.AddDireccion(direccion, empresa, contacto);
                Assert.AreNotEqual(-1, id);
                Assert.IsTrue(registros + 1 == proxy.GetAllDireccion().Length);
                proxy.DeleteDireccion(id);
            }
        }

        [TestMethod]
        public void AddContactoTest()
        {
            //Primero se inserta un contacto válido
            ContactoData contacto = new ContactoData();
            EmpresaData[] empresas = proxy.getAllEmpresa();

            int numContactos = proxy.getAllContacto().Length;

            if(empresas.Length>0)
            {
                contacto.idEmpresa = empresas[1].EmpresaID;
                contacto.nif = "43545342K";
                contacto.nombre = "Pepito piscinas";
        }

            int idContacto=proxy.AddContacto(contacto);
            Assert.AreNotEqual(0,idContacto);

            Assert.AreEqual(numContactos + 1, proxy.getAllContacto().Length);

            proxy.DeleteContacto(contacto, idContacto);

            Assert.AreEqual(numContactos, proxy.getAllContacto().Length);


            //se inserta un contacto vacío
            ContactoData contacto2 = new ContactoData();
            EmpresaData[] empresas2 = proxy.getAllEmpresa();

            int numContactos2 = proxy.getAllContacto().Length;

            if (empresas2.Length > 0)
            {
                contacto2.idEmpresa = empresas2[1].EmpresaID;
                contacto2.nif = "";
                contacto2.nombre = "";
            }

            int idContacto2 = proxy.AddContacto(contacto2);
            Assert.AreEqual(-1, idContacto2);

            Assert.AreEqual(numContactos2, proxy.getAllContacto().Length);

            //Añadir contacto nulo
            int idContacto3 = proxy.AddContacto(null);
            Assert.AreEqual(-1, idContacto3);

        }

        /******************************* TEST EDIT *******************************************
        */
        [TestMethod]
        public void EditUsuarioTest()
        {
            //Se añade un usuario correcto a la base de datos
            UsuarioData usuario = new UsuarioData();
            usuario.login = "EditUsuario";
            usuario.nombre = "Usuario";
            usuario.password = "111111";

            //Obtengo todos los usuarios de la base de datos
            UsuarioData[] usuarios = proxy.getAllUsuarios();
            //Se obtiene el numero de usuarios 
            int numUsuarios = usuarios.Length;
            //Se añade un usuario
            int idUsuario = proxy.addUsuario(usuario);

             //Se añade un usuario correcto a la base de datos
            UsuarioData usuarioEdit = new UsuarioData();
            usuarioEdit.login = "Editado User";
            usuarioEdit.nombre = "Editado";
            usuarioEdit.password = "111111";


            Assert.AreNotEqual(-1,proxy.editUsuario(idUsuario,usuarioEdit));

            proxy.deleteUsuario(idUsuario);

            /************************************************/
            //Se añade un usuario correcto a la base de datos
            UsuarioData usuario2 = new UsuarioData();
            usuario2.login = "EditUsuario2";
            usuario2.nombre = "Usuario2";
            usuario2.password = "111111";

          
            //Se añade un usuario
            int idUsuario2 = proxy.addUsuario(usuario2);

            //Se añade un usuario correcto a la base de datos
            UsuarioData usuarioEdit2 = new UsuarioData();
            usuarioEdit2.login = "";
            usuarioEdit2.nombre = "Editado2";
            usuarioEdit2.password = "111111";

            //Tiene que tener un login relleno. Si no--ERROR
            Assert.AreEqual(-1, proxy.editUsuario(idUsuario2, usuarioEdit2));

            proxy.deleteUsuario(idUsuario2);

            /************************************************/
            //Se añade un usuario correcto a la base de datos
            UsuarioData usuario3 = new UsuarioData();
            usuario3.login = "EditUsuario3";
            usuario3.nombre = "Usuario2";
            usuario3.password = "1111111";


            //Se añade un usuario
            int idUsuario3 = proxy.addUsuario(usuario2);

            //Se añade un usuario correcto a la base de datos
            UsuarioData usuarioEdit3 = new UsuarioData();
            usuarioEdit3.login = "loginEdit";
            usuarioEdit3.nombre = "Editado3";
            usuarioEdit3.password = "";

            //Tiene que tener un login relleno. Si no--ERROR
            Assert.AreEqual(-1, proxy.editUsuario(idUsuario3, usuarioEdit3));

            proxy.deleteUsuario(idUsuario3);
        }
        
        [TestMethod]
        public void EditAccionComercialTest()
        {
            EmpresaData[] listE = proxy.getAllEmpresa();
            UsuarioData[] listU = proxy.getAllUsuarios();
            TipoDeAccionData[] listTA = proxy.GetAllTipoAccion();
            EstadoAccion[] listEA = proxy.GetEstadoAccion();

            if (listE.Length == 0 || listU.Length == 0 || listTA.Length == 0 || listEA.Length == 0) return;

            Assert.IsTrue(proxy.addAccionComercial(null) == -1);

            AccionComercialData accion1 = new AccionComercialData()
            {
                descripcion = "prueba",
                comentarios = "esto es una prueba",
                fechaHora = new DateTime(2000, 12, 02),
                idEmpresa = listE[0].EmpresaID,
                idUsuario = listU[0].idUsuario,
                idEstadoAccion = listEA[0].idEstadoAccion,
                idTipoAccion = listTA[0].idTipoAccion
            };

            int nueva = proxy.addAccionComercial(accion1);
            accion1.idAccion = nueva;
            accion1.descripcion = "cambioprueba1";

            Assert.IsTrue(proxy.editAccionComercial(accion1) == nueva);
            Assert.IsTrue(proxy.getAccionComercial(nueva).descripcion == "cambioprueba1");
            proxy.deleteAccionComercial(nueva);
        }
        /*
        [TestMethod]
        public void EditTipoAccionTest()
        {

        }

        public void EditEstadoAccionTest()
        {

        }
        */
        [TestMethod]
        public void EditEmpresaTest()
        {
            EmpresaData[] empresas = proxy.getAllEmpresa();
            int numEmpresas = empresas.Length;

            //Insertamos una empresa válida, se comprueba que dicho método devuelva un indice distinto de -1 (-1 = error. No insertado)
            int idEmpresaNueva = proxy.addEmpresa("T69696969", "Empresa Editar", "Empresa Editar s.a.", "http://www.testEditar.es", 1);
            Assert.AreNotEqual(-1, idEmpresaNueva);

            //Se edita una empresa
            Assert.IsTrue(proxy.editEmpresa(idEmpresaNueva, "A6969696", "Empresa editada", "EmpresaEditada", "http://www.testEditar.es", 2));

            //Se busca la empresa recien modificada.
            Assert.IsNotNull(proxy.getEmpresaCif("A6969696"));

            //Se comprueba el numero de empresa. Debe aumentar en uno.
            Assert.AreEqual(numEmpresas + 1, proxy.getAllEmpresa().Length);

            proxy.deleteEmpresa(idEmpresaNueva);
        }

        /*
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
            EmpresaData[] listE = proxy.getAllEmpresa();
            if(listE.Length > 0)
            {
                int nuevo = proxy.AddTelefono(tOriginal, listE[0], null);
                Assert.IsTrue(proxy.EditTelefono(new TelefonoData() { idTelefono = nuevo, numero = "cambiado" }) != -1);
                Assert.IsTrue(proxy.GetIdTelefono(nuevo).numero == "cambiado");
                proxy.DeleteTelefono(nuevo);
            }
        }
        
        [TestMethod]
        public void EditEmailTest()
        {
            EmpresaData emp = new EmpresaData();
            EmpresaData[] lista = proxy.getAllEmpresa();
            EmailData email = new EmailData();
            ContactoData contacto = new ContactoData();

            //Intento editar un correo que no existe en la base de datos
            Assert.IsFalse(proxy.editEmail(0, ""));

            //Añado un nuevo email
            int nuevoEmail = proxy.addEmail("correoNuevoEdit@gmail.com", lista[0], contacto);
            //Intento editar el email que se acaba de insertar.
            Assert.IsTrue(proxy.editEmail(nuevoEmail, "emailModificado@gmail.com"));
            proxy.deleteEmail(nuevoEmail);

        }
        
        [TestMethod]
        public void EditDireccionTest()
        {
            Assert.IsTrue(proxy.EditDireccion(null) == -1);
            DireccionData tOriginal = new DireccionData() { domicilio = "domprueba", poblacion = "pobprueba", codPostal = "cp0", provincia = "provprueba" };
            EmpresaData[] listE = proxy.getAllEmpresa();
            if (listE.Length > 0)
            {
                int original = proxy.AddDireccion(tOriginal, listE[0], null);
                DireccionData dir = new DireccionData() { idDireccion = original, domicilio = "cambiado", poblacion = "pobprueba", codPostal = "cp0", provincia = "provprueba" };
                Assert.IsTrue(proxy.EditDireccion(dir) != -1);
                proxy.DeleteDireccion(original);
            }
        }

        [TestMethod]
        public void EditContactoTest()
        {
            //Primero se inserta un contacto válido
            ContactoData contacto = new ContactoData();
            EmpresaData[] empresas = proxy.getAllEmpresa();

            int numContactos = proxy.getAllContacto().Length;

            if (empresas.Length > 0)
            {
                contacto.idEmpresa = empresas[1].EmpresaID;
                contacto.nif = "43545342K";
                contacto.nombre = "Juanito";
            }

            int idContacto = proxy.AddContacto(contacto);
          
            ContactoData contactoEdit = new ContactoData();
            contactoEdit.idContacto = idContacto;
            contactoEdit.idEmpresa = empresas[1].EmpresaID;
            contactoEdit.nif = "6666666K";
            contactoEdit.nombre = "Editado";


            int idContactoEdit=proxy.EditContacto(contactoEdit, idContacto);

            Assert.AreEqual(idContactoEdit, idContacto);

            proxy.DeleteContacto(contacto, idContacto);

            Assert.AreEqual(numContactos, proxy.getAllContacto().Length);
        }

        /******************************* TEST DELETE *******************************************
        */
        [TestMethod]
        public void DeleteUsuarioTest()
        {
            //Se añade un usuario correcto a la base de datos
            UsuarioData usuario = new UsuarioData();
            usuario.login = "Delete Usuario";
            usuario.nombre = "Usuario";
            usuario.password = "22222222";

            //Obtengo todos los usuarios de la base de datos
            UsuarioData[] usuarios = proxy.getAllUsuarios();
            //Se obtiene el numero de usuarios 
            int numUsuarios = usuarios.Length;
            //Se añade un usuario
            int idUsuario = proxy.addUsuario(usuario);

            Assert.AreEqual(numUsuarios + 1, proxy.getAllUsuarios().Length);
            Assert.IsTrue(proxy.deleteUsuario(idUsuario));

            Assert.AreEqual(numUsuarios, proxy.getAllUsuarios().Length);

        }

        [TestMethod]
        public void DeleteAccionComercialTest()
        {
            EmpresaData[] listE = proxy.getAllEmpresa();
            UsuarioData[] listU = proxy.getAllUsuarios();
            TipoDeAccionData[] listTA = proxy.GetAllTipoAccion();
            EstadoAccion[] listEA = proxy.GetEstadoAccion();

            if (listE.Length == 0 || listU.Length == 0 || listTA.Length == 0 || listEA.Length == 0) return;

            int nueva = proxy.addAccionComercial(new AccionComercialData()
            {
                descripcion = "prueba",
                comentarios = "esto es una prueba",
                fechaHora = new DateTime(2000, 12, 02),
                idEmpresa = listE[0].EmpresaID,
                idUsuario = listU[0].idUsuario,
                idEstadoAccion = listEA[0].idEstadoAccion,
                idTipoAccion = listTA[0].idTipoAccion
            });
            int registros = proxy.getAllAccionesComerciales().Length;
            Assert.IsTrue(proxy.deleteAccionComercial(nueva));
            Assert.IsTrue(proxy.getAllAccionesComerciales().Length == registros - 1);
        }
        /*
        [TestMethod]
        public void DeleteTipoAccionTest()
        {

        }

        public void DeleteEstadoAccionTest()
        {

        }
        */
        [TestMethod]
        public void DeleteEmpresaTest()
        {
            EmpresaData[] empresas = proxy.getAllEmpresa();
            int numEmpresas = empresas.Length;

            //Insertamos una empresa válida, se comprueba que dicho método devuelva un indice distinto de -1 (-1 = error. No insertado)
            int idEmpresaNueva = proxy.addEmpresa("T69696969", "Empresa Eliminar test", "Empresa EliminarTest s.a.", "http://www.testEliminar.es", 1);
            Assert.AreNotEqual(-1, idEmpresaNueva);

            //Se comprueba el numero de empresa. Debe aumentar en uno.
            Assert.AreEqual(numEmpresas + 1, proxy.getAllEmpresa().Length);

            proxy.deleteEmpresa(idEmpresaNueva);

            Assert.AreEqual(numEmpresas,proxy.getAllEmpresa().Length);
        }

        /*
        [TestMethod]
        public void DeleteSectorTest()
        {

        }
        */
        [TestMethod]
        public void DeleteTelefonoTest()
        {
            EmpresaData[] listE = proxy.getAllEmpresa();
            if(listE.Length > 0)
            {
                int nuevo = proxy.AddTelefono(new TelefonoData() { numero = "prueba1" }, listE[0], null);
                int registros = proxy.GetAllTelefonos().Length;
                Assert.IsTrue(proxy.DeleteTelefono(nuevo));
                Assert.IsTrue(registros - 1 == proxy.GetAllTelefonos().Length);
            }
            

        }
        
        /// <summary>
        /// Método que comprueba si se elimina correctamente un email de la base de datos.
        /// </summary>
        [TestMethod]
        public void DeleteEmailTest()
        {
            EmpresaData emp = new EmpresaData();
            EmpresaData[] lista = proxy.getAllEmpresa();
            EmailData email = new EmailData();
            ContactoData contacto = new ContactoData();


            //Añado un email de ejemplo
            email.Correo = "ejemploDelete@gmail.com";
            email.EmailID = proxy.addEmail(email.Correo, lista[0], contacto);
           
            EmailData[] listaEmp = proxy.getAllEmail();
            //Obtengo los elementos de la tabla intermedia MailEmpresa
            EmailData[] listaMailEmpresa = proxy.getEmailEmpresa(lista[0].EmpresaID);
            int numeroMailEmpresa=listaMailEmpresa.Length;
            //Se obtienen el numero de elementos antes de eliminar un registro
            int numeroEmp = listaEmp.Length;
            Assert.IsTrue(proxy.deleteEmail(email.EmailID));

            //Obtengo los elementos de la tabla intermedia MailEmpresa
            EmailData[] listaMailEmpresaAfter = proxy.getEmailEmpresa(lista[0].EmpresaID);
            int numeroMailEmpresaAfter = listaMailEmpresaAfter.Length;

            Assert.AreEqual(numeroMailEmpresa-1,numeroMailEmpresaAfter);
            //Se obtiene el numero de elementos despues de eliminar un registro
            listaEmp = proxy.getAllEmail();
            int numeroEmpDelete = listaEmp.Length;
            //Se comprueba que haya un elemento menos después de eliminar.
            Assert.AreEqual(numeroEmp - 1, numeroEmpDelete);

            //Intento Eliminar un elemento con un identificador que no existe
            Assert.IsFalse(proxy.deleteEmail(435466));

        }

        [TestMethod]
        public void DeleteDireccionTest()
        {

            int nuevo = proxy.AddDireccion(new DireccionData() { domicilio = "domprueba", poblacion = "pobprueba", codPostal = "cp0", provincia = "provprueba" }, new EmpresaData() { EmpresaID = 2 }, null);
            int registros = proxy.GetAllDireccion().Length;
            Assert.IsTrue(proxy.DeleteDireccion(nuevo));
            Assert.IsTrue(registros - 1 == proxy.GetAllDireccion().Length);
        }
        
        [TestMethod]
        public void DeleteContactoTest()
        {
            //Primero se inserta un contacto válido y se elimina
            ContactoData contacto = new ContactoData();
            EmpresaData[] empresas = proxy.getAllEmpresa();

            int numContactos = proxy.getAllContacto().Length;

            if (empresas.Length > 0)
            {
                contacto.idEmpresa = empresas[1].EmpresaID;
                contacto.nif = "43545342K";
                contacto.nombre = "Pepito piscinas";
        }

            int idContacto = proxy.AddContacto(contacto);
            Assert.AreNotEqual(0, idContacto);

            Assert.AreEqual(numContactos + 1, proxy.getAllContacto().Length);

            proxy.DeleteContacto(contacto, idContacto);

            Assert.AreEqual(numContactos, proxy.getAllContacto().Length);

           
        }

        /******************************* TEST GET *******************************************
        */
        [TestMethod]
        public void GetUsuarioTest()
        {


            //Obtengo un usuario que sé que existe en la base de datos.
            UsuarioData usuario = new UsuarioData();
            UsuarioData[] usuarios = proxy.getAllUsuarios();
            if(usuarios.Length>1)
            {
                usuario = usuarios[1];
        }

            UsuarioData usuarioGet= proxy.getUsuario(usuarios[1].idUsuario);
            
            Assert.AreEqual(usuarioGet.login,usuario.login);
            Assert.AreEqual(usuarioGet.nombre, usuario.nombre);
            Assert.AreEqual(usuarioGet.password, usuario.password);

            //Se devuelve un usuario con id que no existe en la base de datos.
            UsuarioData user=proxy.getUsuario(34245);

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void GetAccionComercialTest()
        {
            EmpresaData[] listE = proxy.getAllEmpresa();
            UsuarioData[] listU = proxy.getAllUsuarios();
            TipoDeAccionData[] listTA = proxy.GetAllTipoAccion();
            EstadoAccion[] listEA = proxy.GetEstadoAccion();

            if (listE.Length == 0 || listU.Length == 0 || listTA.Length == 0 || listEA.Length == 0) return;

            AccionComercialData accion = new AccionComercialData()
            {
                descripcion = "prueba",
                comentarios = "esto es una prueba",
                fechaHora = new DateTime(2000, 12, 02),
                idEmpresa = listE[0].EmpresaID,
                idUsuario = listU[0].idUsuario,
                idEstadoAccion = listEA[0].idEstadoAccion,
                idTipoAccion = listTA[0].idTipoAccion
            };
            int nueva = proxy.addAccionComercial(accion);
            Assert.IsTrue(proxy.getAccionComercial(nueva).descripcion == "prueba");
            proxy.deleteAccionComercial(nueva);
        }
        
        [TestMethod]
        public void GetIdTipoAccionTest()
        {
            Assert.IsTrue(proxy.GetIdTipoAccion(1).descripcion == "Venta");
            Assert.IsTrue(proxy.GetIdTipoAccion(2).descripcion == "Compra");
        }

        public void GetEstadoAccionTest()
        {
            Assert.IsTrue(proxy.GetEstadoAccion().Length >= 0);
        }

        [TestMethod]
        public void GetEmpresaTest()
        {
            EmpresaData[] empresas = proxy.getAllEmpresa();
            int numEmpresas = empresas.Length;

            //Insertamos una empresa válida, se comprueba que dicho método devuelva un indice distinto de -1 (-1 = error. No insertado)
            int idEmpresaNueva = proxy.addEmpresa("T9999999", "Empresa Get", "Empresa Get s.a.", "http://www.testGet.es", 1);

            //Se comprueba el numero de empresa. Debe aumentar en uno.
            Assert.AreEqual(numEmpresas + 1, proxy.getAllEmpresa().Length);

            Assert.IsNotNull(proxy.getEmpresaCif("T9999999"));
            Assert.IsNull(proxy.getEmpresaCif("sjkgfgkf"));

            proxy.deleteEmpresa(idEmpresaNueva);

            //Se comprueba el numero de empresa. Debe aumentar en uno.
            Assert.AreEqual(numEmpresas, proxy.getAllEmpresa().Length);
        }

        [TestMethod]
        public void GetSectorTest()
        {
            Assert.IsTrue(proxy.GetSector().Length > 0);
        }

        [TestMethod]
        public void GetTelefonoTest()
        {
            TelefonoData t = new TelefonoData() { numero = "prueba" };
            EmpresaData[] listE = proxy.getAllEmpresa();
            if (listE.Length > 0)
            {
                int nuevo = proxy.AddTelefono(t, listE[0], null);
                Assert.IsTrue(proxy.GetIdTelefono(nuevo).numero == t.numero);
                proxy.DeleteTelefono(nuevo);
            }
            
        }


        /// <summary>
        /// Método que hace distintas pruebas sobre el método que devuelve un email.
        /// Se prueban los dos métodos existentes:
        /// - getEmailId()- Devuelve un email pasándole por parámetro su identificador.
        /// - getEmailCorreo()- Devuelve un email pasándole por parámetro un correo electrónico.
        /// </summary>
        [TestMethod]
        public void GetEmailTest()
        {
            EmpresaData emp = new EmpresaData();
            EmpresaData[] lista = proxy.getAllEmpresa();
            EmailData email = new EmailData();
            ContactoData contacto = new ContactoData();


            //Añado un email de ejemplo
            email.Correo = "ejemploUnMail@gmail.com";
            email.EmailID = proxy.addEmail(email.Correo, lista[0], contacto);

            //Se busca un email que se acaba de insertar en la bd
            Assert.IsNotNull(proxy.getEmailCorreo("ejemploUnMail@gmail.com"));
            Assert.IsNotNull(proxy.getEmailId(email.EmailID));

            Assert.IsTrue(proxy.deleteEmail(email.EmailID));

            //Ahora busco un email que se que no existe 
            Assert.IsNull(proxy.getEmailCorreo("noExiste@gmail.com"));
            Assert.IsNull(proxy.getEmailId(456));


        }

        
        [TestMethod]
        public void GetDireccionTest()
        {
            DireccionData t = new DireccionData() { domicilio = "domprueba", poblacion = "pobprueba", codPostal = "cp0", provincia = "provprueba" };
            EmpresaData[] listE = proxy.getAllEmpresa();
            if (listE.Length > 0)
            {
                int nuevo = proxy.AddDireccion(t, listE[0], null);
                int registros = proxy.GetAllDireccion().Length;
                proxy.DeleteDireccion(nuevo);
                Assert.IsTrue(proxy.GetAllDireccion().Length == registros - 1);
            }
        }
/*
        [TestMethod]
        public void GetContactoTest()
        {
            ContactoData[] contactos =proxy.getAllContacto();
            if(contactos.Length>0)
            {
                Assert.IsNotNull(contactos[1]);
            }

            ContactoData contacto= proxy.getContacto(contactos[1].idContacto);

            Assert.AreEqual(contacto.idEmpresa, contactos[1].idEmpresa);
            Assert.AreEqual(contacto.nif, contactos[1].nif);
            Assert.AreEqual(contacto.nombre, contactos[1].nombre);
        }

        /******************************* TEST GETALL *******************************************
        */

        [TestMethod]
        public void GetAllUsuariosTest()
        {
            //Se añade un usuario correcto a la base de datos
            UsuarioData usuario = new UsuarioData();
            usuario.login = "GetAllUsuario";
            usuario.nombre = "Usuario";
            usuario.password = "111111";

            //Obtengo todos los usuarios de la base de datos
            UsuarioData[] usuarios = proxy.getAllUsuarios();
            //Se obtiene el numero de usuarios 
            int numUsuarios = usuarios.Length;
            //Se añade un usuario
            int idUsuario = proxy.addUsuario(usuario);

            Assert.AreEqual(numUsuarios + 1, proxy.getAllUsuarios().Length);
            Assert.IsTrue(proxy.deleteUsuario(idUsuario));


        }
        
        [TestMethod]
        public void GetAllAccionesComercialTest()
        {
            EmpresaData[] listE = proxy.getAllEmpresa();
            UsuarioData[] listU = proxy.getAllUsuarios();
            TipoDeAccionData[] listTA = proxy.GetAllTipoAccion();
            EstadoAccion[] listEA = proxy.GetEstadoAccion();

            if(listE.Length == 0 || listU.Length == 0 || listTA.Length == 0 || listEA.Length == 0) return;
            
            int registros = proxy.getAllAccionesComerciales().Length;
            int nueva = proxy.addAccionComercial(new AccionComercialData() { 
                descripcion = "prueba",
                comentarios = "esto es una prueba",
                fechaHora = new DateTime(2000, 12, 02), 
                idEmpresa = listE[0].EmpresaID, 
                idUsuario = listU[0].idUsuario,
                idEstadoAccion = listEA[0].idEstadoAccion,
                idTipoAccion = listTA[0].idTipoAccion
            });
            Assert.IsTrue(proxy.getAllAccionesComerciales().Length == registros + 1);
            proxy.deleteAccionComercial(nueva);
        }
        [TestMethod]
        public void GetAccionesComercialesUsuarioTest()
        {
            EmpresaData[] listE = proxy.getAllEmpresa();
            EstadoAccion[] listEA = proxy.GetEstadoAccion();
            TipoDeAccionData[] listTA = proxy.GetAllTipoAccion();
            AccionComercialData[] listAC;

            if (listE.Length == 0 || listEA.Length == 0 || listTA.Length == 0) return;

            UsuarioData uNuevo = new UsuarioData() { login = "ivan", nombre = "ivan", password = "ivan" };
            int idUser = proxy.addUsuario(uNuevo);
            
            AccionComercialData nueva = new AccionComercialData()
            {
                descripcion = "prueba1",
                comentarios = "esto es una prueba",
                fechaHora = new DateTime(2000, 12, 02),
                idEmpresa = listE[0].EmpresaID,
                idUsuario = idUser,
                idEstadoAccion = listEA[0].idEstadoAccion,
                idTipoAccion = listTA[0].idTipoAccion
            };
            int idNueva1 = proxy.addAccionComercial(nueva);

            nueva.descripcion = "prueba2";
            int idNueva2 = proxy.addAccionComercial(nueva);

            listAC = proxy.getAccionesComercialesUsuarios(idUser);
            Assert.IsTrue(listAC.Length == 2);
            proxy.deleteAccionComercial(idNueva1);
            proxy.deleteAccionComercial(idNueva2);
            proxy.deleteUsuario(idUser);
        }

        [TestMethod]
        public void GetAccionesComercialesEmpresaTest()
        {
            SectorData[] listS = proxy.GetSector();
            UsuarioData[] listU = proxy.getAllUsuarios();
            EstadoAccion[] listEA = proxy.GetEstadoAccion();
            TipoDeAccionData[] listTA = proxy.GetAllTipoAccion();
            AccionComercialData[] listAC;

            if (listS.Length == 0 || listU.Length == 0 || listEA.Length == 0 || listTA.Length == 0) return;
            
            int idEmpresa = proxy.addEmpresa("prueba", "prueba", "prueba", "prueba", listS[0].idSector);
            
            AccionComercialData nueva = new AccionComercialData()
            {
                descripcion = "prueba1",
                comentarios = "esto es una prueba",
                fechaHora = new DateTime(2000, 12, 02),
                idEmpresa = idEmpresa,
                idUsuario = listU[0].idUsuario,
                idEstadoAccion = listEA[0].idEstadoAccion,
                idTipoAccion = listTA[0].idTipoAccion
            };
            int idNueva1 = proxy.addAccionComercial(nueva);

            nueva.descripcion = "prueba2";
            int idNueva2 = proxy.addAccionComercial(nueva);

            listAC = proxy.getAccionesComercialesEmpresa(idEmpresa);
            Assert.IsTrue(listAC.Length == 2);
            proxy.deleteAccionComercial(idNueva1);
            proxy.deleteAccionComercial(idNueva2);
            proxy.deleteEmpresa(idEmpresa);
        }

        [TestMethod]
        public void GetAllTipoAccionTest()
        {
            Assert.IsTrue(proxy.GetAllTipoAccion().Length > 0);
        }

        [TestMethod]
        public void GetAllEmpresaTest()
        {
            EmpresaData[] empresas = proxy.getAllEmpresa();
            int numEmpresas = empresas.Length;

            //Insertamos una empresa válida, se comprueba que dicho método devuelva un indice distinto de -1 (-1 = error. No insertado)
            int idEmpresaNueva = proxy.addEmpresa("T9999999", "Empresa Get", "Empresa Get s.a.", "http://www.testGet.es", 1);

            //Se comprueba el numero de empresa. Debe aumentar en uno.
            Assert.AreEqual(numEmpresas + 1, proxy.getAllEmpresa().Length);

            proxy.deleteEmpresa(idEmpresaNueva);

            //Se comprueba el numero de empresa. Debe aumentar en uno.
            Assert.AreEqual(numEmpresas, proxy.getAllEmpresa().Length);
        }

        /*
        [TestMethod]
        public void GetAllSectorTest()
        {

        }
        
        */
        [TestMethod]
        public void GetAllTelefonoTest()
        {
            int registros = proxy.GetAllTelefonos().Length;
            EmpresaData[] listE = proxy.getAllEmpresa();
            if(listE.Length > 0)
            {
                int nuevo = proxy.AddTelefono(new TelefonoData() { numero = "prueba" }, listE[0], null);
                Assert.IsTrue(registros + 1 == proxy.GetAllTelefonos().Length);
                proxy.DeleteTelefono(nuevo);
            }
            
        }
        
        [TestMethod]
        public void GetAllEmailTest()
        {
            EmpresaData emp = new EmpresaData();
            EmpresaData[] lista = proxy.getAllEmpresa();
            EmailData email = new EmailData();
            ContactoData contacto = new ContactoData();


            int registros = proxy.getAllEmail().Length;
            int nuevoEmail = proxy.addEmail("correoNuevoAllEmail@gmail.com", lista[0], contacto);

            Assert.IsTrue(registros + 1 == proxy.getAllEmail().Length);
            proxy.deleteEmail(nuevoEmail);
        }
        /*
        [TestMethod]
        public void GetAllDireccionTest()
        {

        }

        */
        [TestMethod]
        public void GetAllContactoTest()
        {
            
            //Primero se inserta un contacto válido
            ContactoData contacto = new ContactoData();
            EmpresaData[] empresas = proxy.getAllEmpresa();

            int numContactos = proxy.getAllContacto().Length;

            if (empresas.Length > 0)
            {
                contacto.idEmpresa = empresas[1].EmpresaID;
                contacto.nif = "43545342K";
                contacto.nombre = "Pepito piscinas";
            }

            int idContacto = proxy.AddContacto(contacto);
            Assert.AreNotEqual(0, idContacto);

            Assert.AreEqual(numContactos + 1, proxy.getAllContacto().Length);

            proxy.DeleteContacto(contacto, idContacto);

            //Busco un elemento que no existe
            Assert.IsNull(proxy.getContacto(345435));
        }

    }
}
