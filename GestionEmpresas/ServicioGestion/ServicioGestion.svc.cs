
using ServicioGestion.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioGestion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioGestion" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioGestion.svc or ServicioGestion.svc.cs at the Solution Explorer and start debugging.
    public class ServicioGestion : IServicioGestion
    {
        /***************************************************************
        ****Métodos tabla Email. 
         *AddEmail -- Añadir , 
         *getAllEmail -- Devuelve todos los registros
         *getEmail -- Devuelve un registro concreto de la tabla Email
         *deleteEmail -- Elimina un registro de la tabla según su identificador
         *editEmail -- Modificacion de un registro concreto
        ***************************************************************/ 
       /// <summary>
        /// /// Permite insertar un email que no exista en la base de datos. Como el Email está relacionado obligatoriamente con una empresa o un contacto uno de los dos parámetros será null.
       /// </summary>
       /// <param name="correo"></param>
       /// <param name="empData"></param>
       /// <param name="conData"></param>
       /// <returns></returns>
        public bool addEmail(string correo, EmpresaData empData, ContactoData conData)
        {
            if (correo == ""||correo==null) return false;
            if (empData.EmpresaID == 0 && conData.idContacto == 0) return false;
            if (empData.EmpresaID != 0 && conData.idContacto != 0) return false;

            try
            {
                Email p = new Email();
                p.correo = correo;

                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    if (empData.EmpresaID != 0)
                    {
                        var datos = from empresas in db.Empresa
                                    where empresas.idEmpresa == empData.EmpresaID
                                    select empresas;
                        p.Empresa.Add(datos.First());
                    }
                    else
                    {
                        var datos = from contactos in db.Contacto
                                    where contactos.idContacto == conData.idContacto
                                    select contactos;
                        p.Contacto.Add(datos.First());
                    }

                    db.Email.Add(p);
                    db.SaveChanges();
                }
                return true;
               
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("EError SQL" + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO LISTADO DE EMAILS"));
            }
        }

        /// <summary>
        /// Método que obtiene todos los emails contenidos en la tabla Email
        /// </summary>
        /// <returns>Devuelve una lista de objetos Email.</returns>
        public List<EmailData> getAllEmail()
        {
            List<EmailData> datos = new List<EmailData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from email in db.Email
                                  select email;

                    foreach (Email co in resulta)
                    {
                        EmailData correoData = new EmailData()
                        {
                            EmailID = co.idEmail,
                            Correo = co.correo
                        };
                        datos.Add(correoData);

                    }
                    return datos;
                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("EError SQL" + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO LISTADO DE EMAILS"));
            }

        }


        /// <summary>
        /// Método que devuelve un registro Email concreto.
        /// </summary>
        /// <param name="id"> identificador a buscar en la tabla Emails.</param>
        /// <returns>Devuelve un objeto EmailData o null si no lo encuentra.</returns>
        public EmailData getEmailId(int id)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from mail in db.Email
                                  where mail.idEmail == id
                                  select mail;

                    foreach (Email co in resulta)
                    {
                        EmailData correoData = new EmailData()
                        {
                            EmailID = co.idEmail,
                            Correo = co.correo
                        };

                        return correoData;
                    }

                    return null;
                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("EError SQL" + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO LISTADO DE EMAILS"));
            }

        }

        /// <summary>
        /// Método que devuelve un registro Email concreto.
        /// </summary>
        /// <param name="correo"> Correo o email a buscar en la tabla Emails.</param>
        /// <returns>Devuelve un objeto EmailData o null si no lo encuentra.</returns>
        public EmailData getEmailCorreo(string correo)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from mail in db.Email
                                  where mail.correo == correo
                                  select mail;

                    foreach (Email co in resulta)
                    {
                        EmailData correoData = new EmailData()
                        {
                            EmailID = co.idEmail,
                            Correo = co.correo
                        };

                        return correoData;
                    }

                    return null;
                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("EError SQL" + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO LISTADO DE EMAILS"));
            }

        }

        /// <summary>
        /// Método que elimina un registro email de la tabla Email
        /// </summary>
        /// <param name="idEmail">identificador único de un registro email</param>
        /// <returns>Devuelve true si se ha eliminado correctamente y false si no.</returns>
        public bool deleteEmail(int idEmail)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consult = from correo in db.Email
                                  where correo.idEmail == idEmail
                                  select correo;

                    //si el objeto es nulo
                    if (idEmail == null) return false;

                    Email email = consult.First();

                    db.Email.Remove(email);
                    db.SaveChanges();
  
                }
                return true;
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("EError SQL" + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO LISTADO DE EMAILS"));
            }
        }



        /// <summary>
        /// Método que edita el campo correo de un registro de la tabla email
        /// </summary>
        /// <param name="id">Identificador del email a editar po modificar.</param>
        /// <param name="correo">Correo a modificar.</param>
        /// <returns>Devuelve true si se ha editado correctamente el registro, False si no.</returns>
        public bool editEmail(int id, string correo)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consult = from co in db.Email
                                  where co.idEmail == id
                                  select co;

               
                        Email mailMod = consult.First();

                        mailMod.correo = correo;
                        db.SaveChanges();
                   
                        return true;
                   

                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL" + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO LISTADO DE EMAILS"));
            }
        }
        /***************************************************************
        *******************************FIN EMAIL************************
        ***************************************************************/


        /***************************************************************
        ****************************  Direccion ************************
        ***************************************************************/
       
        /// <summary>
        /// Metodo que añade un objeto street de tipo DireccionData a la bd
        /// </summary>
        /// <param name="street"></param>
        /// <returns></returns>
        public bool AddDireccion(DireccionData t, EmpresaData empData, ContactoData conData)
        {
            if (t == null) return false;
            if (empData.EmpresaID == 0 && conData.idContacto == 0) return false;
            if (empData.EmpresaID != 0 && conData.idContacto != 0) return false;

            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    Direccion nueva = new Direccion();

                    nueva.idDireccion = t.idDireccion;
                    nueva.domicilio = t.domicilio;
                    nueva.poblacion = t.poblacion;
                    nueva.provincia = t.provincia;
                    nueva.codPostal = t.codPostal;

                    if (empData.EmpresaID != 0)
                    {
                        var datos = from empresas in bd.Empresa
                                    where empresas.idEmpresa == empData.EmpresaID
                                    select empresas;
                        nueva.Empresa.Add(datos.First());
                    }
                    else
                    {
                        var datos = from contactos in bd.Contacto
                                    where contactos.idContacto == conData.idContacto
                                    select contactos;
                        nueva.Contacto.Add(datos.First());
                    }

                    bd.Direccion.Add(nueva);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("General"));

                throw fault;
            }
        }// Fin del metodo añadir AddDireccion

        /// <summary>
        /// Metodo que a partir de un objeto y un id elimina una direccion.
        /// </summary>
        /// <param name="street"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDireccion(DireccionData street, int id)
        {
            List<DireccionData> direccionBorrar = new List<DireccionData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resultado = from calle in db.Direccion
                                    where (calle.idDireccion == id)
                                    select calle;

                    foreach (var calle in resultado) // Un foreach que elimina la fila completa
                    {
                        db.Direccion.Remove(calle); // Borra el objeto
                    }
                    db.SaveChanges(); // Se guarda los campios realizados

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException("No se puede acceder a la BD de datos." + ex.Message);
            }
        }// Fin del metodo DeleteDireccion

        /// <summary>
        /// Meotodo que a partir  de un objeto street de tipo DireccionData y un id me borra un registro de la BD
        /// </summary>
        /// <param name="street"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EditDireccion(DireccionData street, int id)
        {
            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var consulta = from calle in bd.Direccion
                                   where calle.idDireccion == id
                                   select calle;

                    Direccion nueva = consulta.First();

                    nueva.idDireccion = street.idDireccion;
                    nueva.domicilio = street.domicilio;
                    nueva.poblacion = street.poblacion;
                    nueva.provincia = street.provincia;
                    nueva.codPostal = street.codPostal;

                    bd.SaveChanges();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("General"));

                throw fault;
            }
        }// Fin del metodo EditDireccion

        /// <summary>
        /// Metodo que me devuelve todas las direcciones de la BD
        /// </summary>
        /// <returns></returns>
        public List<DireccionData> GetDireccion()
        {
            List<DireccionData> lst = new List<DireccionData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from calle in db.Direccion
                                   select new DireccionData()
                                   {
                                       idDireccion = calle.idDireccion,
                                       domicilio = calle.domicilio,
                                       poblacion = calle.provincia,
                                       provincia = calle.provincia,
                                       codPostal = calle.codPostal
                                   };
                    lst = consulta.ToList();

                    if (lst.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return lst;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error en acceso a datos. " + ex.Message);
            }
        }// Fin del GetDireccion

        /***************************************************************
        **************************** Fin Direccion ************************
        ***************************************************************/

        /***************************************************************
        ***************************** Sector ***************************
        ***************************************************************/

        /// <summary>
        /// Metodo que me devuelve todos los sectores de la BD
        /// </summary>
        /// <returns></returns>
        public List<SectorData> GetSector()
        {
            List<SectorData> lst = new List<SectorData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from sector in db.Sector
                                   select new SectorData()
                                   {
                                       idSector = sector.idSector,
                                       descripcion = sector.descripcion,
                                   };
                    lst = consulta.ToList();

                    if (lst.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return lst;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error en acceso a datos. " + ex.Message);
            }
        }// Fin del GetSector

        /***************************************************************
        **************************** Fin Sector ************************
        ****************************************************************/


        /***************************************************************
        ******************  Estado de accion ***************************
        ****************************************************************/

        /// <summary>
        /// Metodo que me devuelve todos los sectores de la BD
        /// </summary>
        /// <returns></returns>
        public List<EstadoAccion> GetEstadoAccion()
        {
            List<EstadoAccion> lst = new List<EstadoAccion>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from estadoAccion in db.EstadoDeAccion
                                   select new EstadoAccion()
                                   {
                                       idEstadoAccion = estadoAccion.idEstadoAccion,
                                       descripcion = estadoAccion.descripcion,
                                   };
                    lst = consulta.ToList();

                    if (lst.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return lst;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error en acceso a datos. " + ex.Message);
            }
        }// Fin del GetSector

        /***************************************************************
        ******************  Fin Estado de accion ***********************
        ****************************************************************/
        /***************************************************************
         *                      Usuario
         ***************************************************************/
        /// <summary>
        /// Método que añade un usuario a la base de datos
        /// </summary>
        /// <param name="usuario"> Objeto usuario a añadir en la base de datos</param>
        /// <returns>Devuelve true si se ha añadido el registro correctamente. False si no.</returns>
        public bool addUsuario(UsuarioData usuario)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    Usuario nuevo = new Usuario();
                    nuevo.login = usuario.login;
                    nuevo.nombre = usuario.nombre;
                    nuevo.password = usuario.password;

                    db.Usuario.Add(nuevo);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("ERROR SQL: " + ex.Message,
                                                            new FaultCode("SQL"));
                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("ERROR: " + ex.Message,
                                                            new FaultCode("GENERAL"));
                throw fault;
            }
        }
        /// <summary>
        /// Método que elimina un registro usuario de la tabla Usuario
        /// </summary>
        /// <param name="idUsuario">identificador único de un registro usuario</param>
        /// <returns>Devuelve true si se ha eliminado correctamente y false si no.</returns>
        public bool deleteUsuario(int idUsuario)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from usuario in db.Usuario
                                   where usuario.idUsuario == idUsuario
                                   select usuario;

                    if (consulta.ToList().Count != 0)
                    {
                        Usuario u = consulta.First();
                        db.Usuario.Remove(u);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("ERROR SQL: " + ex.Message,
                                                            new FaultCode("SQL"));
                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("ERROR: " + ex.Message,
                                                            new FaultCode("GENERAL"));
                throw fault;
            }
        }
        /// <summary>
        /// Método que edita un usuario de un registro de la tabla Usuario
        /// </summary>
        /// <param name="id">Identificador del usuario a editar.</param>
        /// <param name="correo">Objeto usuario que contiene los datos a modificar</param>
        /// <returns>Devuelve true si se ha modificado el registro correctamente. False si no.</returns>
        public bool editUsuario(int idUsuario, UsuarioData user)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from usuario in db.Usuario
                                   where usuario.idUsuario == idUsuario
                                   select usuario;

                    if (consulta.ToList().Count != 0)
                    {
                        Usuario u = consulta.First();
                        u.idUsuario = user.idUsuario;
                        u.login = user.login;
                        u.nombre = user.nombre;
                        u.password = user.password;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("ERROR SQL: " + ex.Message,
                                                            new FaultCode("SQL"));
                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("ERROR: " + ex.Message,
                                                            new FaultCode("GENERAL"));
                throw fault;
            }
        }
        /// <summary>
        /// Método que obtiene todos los usuarios contenidos en la tabla Usuario
        /// </summary>
        /// <returns>Devuelve una lista de objetos Usuario</returns>
        public List<UsuarioData> getAllUsuarios()
        {
            List<UsuarioData> lst = new List<UsuarioData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from usuario in db.Usuario
                                   select usuario;

                    foreach (Usuario user in consulta)
                    {
                        UsuarioData u = new UsuarioData();
                        u.idUsuario = user.idUsuario;
                        u.login = user.login;
                        u.nombre = user.nombre;
                        u.password = user.password;

                        lst.Add(u);
                    }
                }
                return lst;
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("ERROR SQL: " + ex.Message,
                                                            new FaultCode("SQL"));
                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("ERROR: " + ex.Message,
                                                            new FaultCode("GENERAL"));
                throw fault;
            }
        }
        /// <summary>
        /// Método que devuelve un registro Usuario concreto.
        /// </summary>
        /// <param name="id"> identificador a buscar en la tabla Usuario.</param>
        /// <returns>Devuelve un objeto UsuarioData.</returns>
        public UsuarioData getUsuario(int idUsuario)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from usuario in db.Usuario
                                   where usuario.idUsuario == idUsuario
                                   select new UsuarioData()
                                   {
                                       idUsuario = usuario.idUsuario,
                                       login = usuario.login,
                                       nombre = usuario.nombre,
                                       password = usuario.password
                                   };
                    return consulta.First();
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("ERROR SQL: " + ex.Message,
                                                            new FaultCode("SQL"));
                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("ERROR: " + ex.Message,
                                                            new FaultCode("GENERAL"));
                throw fault;
            }
        }
        /***************************************************************
         *                     Fin Usuario
         ***************************************************************/

        /***************************************************************
        ************************ Contacto ******************************
        ****************************************************************/

        /// <summary>
        /// Metodo que me devuelve una lista de contactos
        /// </summary>
        /// <returns></returns>
        public List<ContactoData> GetContacto()
        {
            List<ContactoData> lst = new List<ContactoData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from contacto in db.Contacto
                                   select new ContactoData()
                                   {
                                       idContacto = contacto.idContacto,
                                       idEmpresa = (int)contacto.idEmpresa,
                                       nif = contacto.nif,
                                       nombre = contacto.nombre,
                                   };
                    lst = consulta.ToList();

                    if (lst.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return lst;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error en acceso a datos. " + ex.Message);
            }
        }// Fin del GetContacto

        /// <summary>
        /// Metodo que elimina un contacto a partir de un objeto contacto de tipo ContactoData y de un id
        /// </summary>
        /// <returns></returns>
        public bool DeleteContacto(ContactoData contacto, int id)
        {
            List<ContactoData> empresaBorrar = new List<ContactoData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resultado = from contact in db.Contacto
                                    where (contact.idContacto == id)
                                    select contact;

                    foreach (var contact in resultado) // Un foreach que elimina la fila completa
                    {
                        db.Contacto.Remove(contact); // Borra el objeto
                    }
                    db.SaveChanges(); // Se guarda los campios realizados

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException("No se puede acceder a la BD de datos." + ex.Message);
            }
        }// Fin del DeleteCon

        /// <summary>
        /// Metodo que añade un nuevo contacto a la base de datos a partir de un objeto contacto de tipo ContactoData
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        public bool AddContacto(ContactoData contacto)
        {
            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    Contacto nueva = new Contacto();

                    nueva.idContacto = contacto.idContacto;
                    nueva.nif = contacto.nif;
                    nueva.nombre = contacto.nombre;
                    nueva.idEmpresa = contacto.idEmpresa;

                    bd.Contacto.Add(nueva);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("General"));

                throw fault;
            }
        }// Fin del AddContacto

        /// <summary>
        /// Metodo que a partir de un objeto e id me edita un contacto
        /// </summary>
        /// <param name="contacto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EditContacto(ContactoData contacto, int id)
        {
            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var consulta = from contact in bd.Contacto
                                   where contact.idContacto == id
                                   select contact;

                    Contacto nueva = consulta.First();

                    nueva.idContacto = contacto.idContacto;
                    nueva.idEmpresa = contacto.idEmpresa;
                    nueva.nif = contacto.nif;
                    nueva.nombre = contacto.nombre;

                    bd.SaveChanges();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("General"));

                throw fault;
            }
        }// Fin del EditContacto

        /***************************************************************
        ******************** Fin Contacto ******************************
        ****************************************************************/

        /******************* METODOS MAS COOL *******************/
        /// <summary>
        /// Metodo que a partir de un idEmpres obtengo todas las direcciones de esa empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<DireccionData> getDirecionesEmpresa(int idEmpresa)
        {
          try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from street in db.Direccion
                                   where street.idDireccion == idEmpresa
                                   select new DireccionData()
                                   {
                                       idDireccion = street.idDireccion,
                                       domicilio = street.domicilio,
                                       poblacion = street.poblacion,
                                       provincia = street.provincia,
                                       codPostal = street.codPostal
                                   };
                    return consulta.ToList();
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("ERROR SQL: " + ex.Message,  new FaultCode("SQL"));
                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("ERROR: " + ex.Message, new FaultCode("GENERAL"));
                throw fault;
            }
        }// Fin del getDirecionesEmpresa

        /// <summary>
        /// Metodo que a partir de un idContacto me muestra todas las direciones de un contacto
        /// </summary>
        /// <param name="Contacto"></param>
        /// <returns></returns>
        public List<ContactoData> getDirecionesContacto(int Contacto)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from cnt in db.Contacto
                                   where cnt.idContacto == Contacto
                                   select new ContactoData()
                                   {
                                       idContacto = cnt.idContacto,
                                       idEmpresa = (int)cnt.idEmpresa,
                                       nif = cnt.nif,
                                       nombre = cnt.nombre,
                                   };
                    return consulta.ToList();
                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("ERROR SQL: " + ex.Message, new FaultCode("SQL"));
                throw fault;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("ERROR: " + ex.Message, new FaultCode("GENERAL"));
                throw fault;
            }
        }
        /***************** FIN METODOS MAS COOL *****************/

    }
}
