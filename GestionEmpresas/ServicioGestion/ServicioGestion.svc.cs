
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
        /********************************************************************/
        /*******************************LUISMI*******************************/
        /********************************************************************/


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
        public int addEmail(string correo, EmpresaData empData, ContactoData conData)
        {
            int indice = -1;

            if (correo == "" || correo == null || empData == null && conData == null) return -1;
            if (empData.EmpresaID == 0 && conData.idContacto == 0) return -1;
            if (empData.EmpresaID != 0 && conData.idContacto != 0) return -1;

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

                    indice = p.idEmail;

                    return indice;
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
                FaultException fault = new FaultException("Error SQL" + ex.Message, new FaultCode("SQL"));

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
                    if (consult.ToList().Count == 0) return false; //si no devuelve ningun resultado.

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
            if (id == null) return false;
            if (correo == null) return false;
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consult = from co in db.Email
                                  where co.idEmail == id
                                  select co;


                    if (consult.ToList().Count == 0) return false;
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

        /// <summary>
        /// Método que añade un nuevo registro en la tabla Empresa
        /// </summary>
        /// <param name="cif">Cif de la empresa a insertar</param>
        /// <param name="nombreComercial">Nombre Comercial de la empresa a insertar</param>
        /// <param name="razon">Razón Social de la empresa a insertar</param>
        /// <param name="web">Página Web de la empresa a insertar</param>
        /// <param name="sector">Identificador de sector de la empresa a insertar</param>
        /// <returns>Devuelve True, si se ha insertado correctamente. Devuelve False si no.</returns>
        public bool addEmpresa(string cif, string nombreComercial, string razon, string web, int sector)
        {
            try
            {
                Empresa emp = new Empresa();
                emp.cif = cif;
                emp.nombreComercial = nombreComercial;
                emp.razonSocial = razon;
                emp.web = web;
                emp.idSector = sector;

                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    db.Empresa.Add(emp);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO AÑADIR EMAIL"));
            }
        }

        /// <summary>
        /// Método que devuelve todos los registros de la tabla Empresa.
        /// </summary>
        /// <returns>Devuelve una lista de Empresas</returns>
        public List<EmpresaData> getAllEmpresa()
        {
            List<EmpresaData> datos = new List<EmpresaData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from empresa in db.Empresa
                                  select empresa;

                    foreach (Empresa em in resulta)
                    {
                        EmpresaData emData = new EmpresaData()
                        {
                            EmpresaID = em.idEmpresa,
                            cif = em.cif,
                            nombreComercial = em.nombreComercial,
                            razonSocial = em.razonSocial,
                            web = em.web,
                            sector = em.Sector.descripcion
                        };
                        datos.Add(emData);

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
        /// Método que busca una empresa según un cif
        /// </summary>
        /// <param name="cif">Cif a buscar de la empresa</param>
        /// <returns>Devuelve un objeto empresa. O null si no encuentra nada.</returns>
        public EmpresaData getEmpresaCif(string cif)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from empresa in db.Empresa
                                  where empresa.cif == cif
                                  select empresa;

                    foreach (Empresa em in resulta)
                    {
                        EmpresaData empData = new EmpresaData()
                        {
                            EmpresaID = em.idEmpresa,
                            cif = em.cif,
                            nombreComercial = em.nombreComercial,
                            razonSocial = em.razonSocial,
                            web = em.web,
                            sector = em.Sector.descripcion
                        };

                        return empData;
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
        /// Método que devuelve una empresa según un id determinado
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Devuelve un objeto empresa</returns>
        public EmpresaData getEmpresaId(int id)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from empresa in db.Empresa
                                  where empresa.idEmpresa == id
                                  select empresa;

                    foreach (Empresa em in resulta)
                    {
                        EmpresaData empData = new EmpresaData()
                        {
                            EmpresaID = em.idEmpresa,
                            cif = em.cif,
                            nombreComercial = em.nombreComercial,
                            razonSocial = em.razonSocial,
                            web = em.web,
                            sector = em.Sector.descripcion
                        };

                        return empData;
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
        /// Método que consulta empresa por Sector
        /// </summary>
        /// <param name="idSector">Identificador del sector para buscar</param>
        /// <returns></returns>
        public List<EmpresaData> getEmpresaSector(int idSector)
        {
            List<EmpresaData> datos = new List<EmpresaData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from empresa in db.Empresa
                                  where empresa.idSector == idSector
                                  select empresa;

                    foreach (Empresa em in resulta)
                    {
                        EmpresaData emData = new EmpresaData()
                        {
                            cif = em.cif,
                            nombreComercial = em.nombreComercial,
                            razonSocial = em.razonSocial,
                            web = em.web,
                            sector = em.Sector.descripcion
                        };
                        datos.Add(emData);

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
        /// Método que elimina un registro empresa de la tabla Empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public bool deleteEmpresa(int idEmpresa)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consult = from emp in db.Empresa
                                  where emp.idEmpresa == idEmpresa
                                  select emp;

                    Empresa email = consult.First();

                    db.Empresa.Remove(email);
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
        /// Método que edita una empresa 
        /// </summary>
        /// <param name="idEmpresa">Identificador de la empresa a modificar</param>
        /// <param name="cif">Cif de la empresa modificada</param>
        /// <param name="nombreComercial">Nombre Comercial de la nueva empresa</param>
        /// <param name="razon">Razón Social de la nueva empresa</param>
        /// <param name="web">Web de la empresa a modificar</param>
        /// <param name="idSector">Sector de la empresa a modificar</param>
        /// <returns>Devuelve true si se ha modificado correctamente.</returns>
        public bool editEmpresa(int idEmpresa, string cif, string nombreComercial, string razon, string web, int idSector)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consult = from em in db.Empresa
                                  where em.idEmpresa == idEmpresa
                                  select em;


                    Empresa empMod = consult.First();

                    empMod.idEmpresa = idEmpresa;
                    empMod.cif = cif;
                    empMod.nombreComercial = nombreComercial;
                    empMod.razonSocial = razon;
                    empMod.web = web;
                    empMod.idSector = idSector;

                    db.SaveChanges();

                    return true;

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

        /***************************************************************
        *******************************FIN EMPRESA**********************
        ***************************************************************/

        /***************************************************************
        ******************************* EMAIL-EMPRESA********************
        ***************************************************************/

        /// <summary>
        /// Método que devuelve todos los emails de una empresa en concreto.
        /// </summary>
        /// <param name="idEmpresa">Identificador de la empresa de la que queremos listar sus emails</param>
        /// <returns>Devuelve una lista de emails de una empresa en concreto.</returns>
        public List<EmailData> getMailEmpresa(int idEmpresa)
        {
            List<EmailData> list = new List<EmailData>();
            EmailData email;
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from empresa in db.Empresa
                                  where empresa.idEmpresa == idEmpresa
                                  select empresa;


                    Empresa empresaResult = resulta.First();

                    foreach (Email em in empresaResult.Email)
                    {
                        email = new EmailData();
                        email.EmailID = em.idEmail;
                        email.Correo = em.correo;
                        list.Add(email);
                    }

                    return list;
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

        /***************************************************************
        *******************************FIN EMAIL-EMPRESA****************
        ***************************************************************/

        /***************************************************************
       ******************************* EMAIL-CONTACTO********************
       ***************************************************************/
        public List<EmailData> getMailContacto(int idContacto)
        {
            List<EmailData> list = new List<EmailData>();
            EmailData mail;
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var resulta = from cont in db.Contacto
                                  where cont.idContacto == idContacto
                                  select cont;


                    Contacto contResult = resulta.First();

                    foreach (Email em in contResult.Email)
                    {
                        mail = new EmailData();

                        mail.EmailID = em.idEmail;
                        mail.Correo = em.correo;
                        list.Add(mail);
                    }

                    return list;
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


        /***************************************************************
       *******************************FIN EMAIL-CONTACTO********************
       ***************************************************************/

        /********************************************************************/
        /*******************************FIN LUISMI***************************/
        /********************************************************************/


        /********************************************************************/
        /*******************************JORGE********************************/
        /********************************************************************/

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
            if (t == null || empData == null || conData == null) return false;
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
                    nuevo.password = PasswordManager.getMD5(usuario.password);

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
                        u.password = PasswordManager.getMD5(user.password);
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
        /// 
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<DireccionData> getDirecionesEmpresa(int idEmpresa)
        {
            try
            {
                List<DireccionData> street = new List<DireccionData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var data = from empresas in bd.Empresa
                               where empresas.idEmpresa == idEmpresa
                               select empresas;

                    foreach (Direccion calle in data.First().Direccion)
                    {
                        street.Add(new DireccionData()
                        {
                            idDireccion = calle.idDireccion,
                            domicilio = calle.domicilio,
                            poblacion = calle.poblacion,
                            provincia = calle.provincia,
                            codPostal = calle.codPostal

                        });
                    }

                    return street;
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
        }// Fin del getDirecionesEmpresa

        /// <summary>
        /// Metodo que a partir de un idContacto me muestra todas las direciones de un contacto
        /// </summary>
        /// <param name="Contacto"></param>
        /// <returns></returns>
        public List<DireccionData> getDirecionesContacto(int idContacto)
        {
            try
            {
                List<DireccionData> street = new List<DireccionData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var data = from contacto in bd.Contacto
                               where contacto.idContacto == idContacto
                               select contacto;

                    foreach (Direccion calle in data.First().Direccion)
                    {
                        street.Add(new DireccionData()
                        {
                            idDireccion = calle.idDireccion,
                            domicilio = calle.domicilio,
                            poblacion = calle.poblacion,
                            provincia = calle.provincia,
                            codPostal = calle.codPostal

                        });
                    }

                    return street;
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

        /********************************************************************/
        /*******************************FIN JORGE****************************/
        /********************************************************************/

        /********************************************************************/
        /*******************************IVAN*********************************/
        /********************************************************************/

        /**************************** TELEFONOS *****************************/
        /// <summary>
        /// Permite obtener un teléfono por su id
        /// <param name="idTelefono">El id del teléfono a buscar.</param>
        /// <returns>El telefono buscado.</returns>
        public TelefonoData GetIdTelefono(int idTelefono)
        {
            try
            {
                List<TelefonoData> t = new List<TelefonoData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from telefonos in bd.Telefono
                                where telefonos.idTelefono== idTelefono
                                select new TelefonoData()
                                {
                                    idTelefono = telefonos.idTelefono,
                                    numero = telefonos.numero
                                };
                    t = datos.ToList();
                }
                if (t.Count == 0) return null;
                else return t.First();
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

        /// <summary>
        /// Permite buscar un teléfono por su número.
        /// </summary>
        /// <param name="numero">El número del teléfono a buscar.</param>
        /// <returns>El teléfonobuscado.</returns>
        public TelefonoData GetNumeroTelefono(string numero)
        {
            try
            {
                List<TelefonoData> t = new List<TelefonoData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from telefonos in bd.Telefono
                                where telefonos.numero == numero
                                select new TelefonoData()
                                {
                                    idTelefono = telefonos.idTelefono,
                                    numero = telefonos.numero
                                };
                    t = datos.ToList();
                }
                if (t.Count == 0) return null;
                else return t.First();
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

        /// <summary>
        /// Permite obtener el listado de teléfonos existentes en la base de datos.
        /// </summary>
        /// <returns>La lista de teléfonos.</returns>
        public List<TelefonoData> GetAllTelefonos()
        {
            try
            {
                List<TelefonoData> listado = new List<TelefonoData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from telefonos in bd.Telefono
                                select telefonos;
                    foreach(Telefono tlf in datos)
                    {
                        TelefonoData tdata = new TelefonoData()
                        {
                            idTelefono = tlf.idTelefono,
                            numero = tlf.numero
                        };
                        listado.Add(tdata);
                    }
                }
                return listado;
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

        /// <summary>
        /// Permite insertar un teléfono que no exista en la base de datos. Como el teléfono está relacionado obligatoriamente con una empresa o un contacto uno de los dos parámetros será null.
        /// </summary>
        /// <param name="t">Teléfono a insertar.</param>
        /// <param name="empData">Empresa a la que pertenece el teléfono a insertar.</param>
        /// <param name="conData">Contacto al que pertenece el teléfono a insertar.</param>
        /// <returns>True si se ha insertado.</returns>
        public int AddTelefono(TelefonoData t, EmpresaData empData, ContactoData conData)
        {
            if (t == null) return -1;
            if (empData == null && conData == null) return -1;
            if (empData != null && conData != null) return -1;
            
            try
            {
                int id;
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    Telefono telefono = new Telefono()
                    {
                        idTelefono = t.idTelefono,
                        numero = t.numero,
                    };

                    if (empData != null)
                    {
                        var datos = from empresas in bd.Empresa
                                    where empresas.idEmpresa == empData.EmpresaID
                                    select empresas;
                        telefono.Empresa.Add(datos.First());
                    }
                    else
                    {
                        var datos = from contactos in bd.Contacto
                                    where contactos.idContacto == conData.idContacto
                                    select contactos;
                        telefono.Contacto.Add(datos.First());
                    }

                    bd.Telefono.Add(telefono);
                    bd.SaveChanges();
                    return telefono.idTelefono;
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

        /// <summary>
        /// Permite editar un teléfono que exista en la base de datos. Como el teléfono está relacionado obligatoriamente con una empresa o un contacto uno de los dos parámetros será null.
        /// </summary>
        /// <param name="t">El teléfono a editar.</param>
        /// <returns>True si se ha editado.</returns>
        public int EditTelefono(TelefonoData t)
        {
            if (t == null) return -1;

            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var data = from telefonos in bd.Telefono
                               where telefonos.idTelefono == t.idTelefono
                               select telefonos;

                    Telefono telefono = data.First();
                    telefono.numero = t.numero;

                    bd.SaveChanges();
                    return telefono.idTelefono;
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
         
        /// <summary>
        /// Permite eliminar un teléfono de la base de datos.
        /// </summary>
        /// <param name="t">El teléfono a eliminar</param>
        /// <returns>True si lo elimina, false si no.</returns>
        public bool DeleteTelefono(int idTelefono)
        {
            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from telefonos in bd.Telefono
                                where telefonos.idTelefono == idTelefono
                                select telefonos;

                    bd.Telefono.Remove(datos.First());
                    bd.SaveChanges();
                    return true;
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

        /******************************************* TIPOS DE ACCION *****************************************/

        ///// <summary>
        ///// Elimina un tipo de acción existente.
        ///// </summary>
        ///// <param name="idTipoAccion">El id del tipo de acción.</param>
        ///// <returns>True si se ha eliminado.</returns>
        //public bool DeleteTipoAccion(int idTipoAccion)
        //{
        //    try
        //    {
        //        using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
        //        {
        //            var datos = from tipos in bd.TipoDeAccion
        //                        where tipos.idTipoAccion== idTipoAccion
        //                        select tipos;

        //            bd.TipoDeAccion.Remove(datos.First());
        //            bd.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        FaultException fault = new FaultException("ERROR SQL: " + ex.Message, new FaultCode("SQL"));
        //        throw fault;
        //    }
        //    catch (Exception ex)
        //    {
        //        FaultException fault = new FaultException("ERROR: " + ex.Message, new FaultCode("GENERAL"));
        //        throw fault;
        //    }
        //}

        /// <summary>
        /// Devuelve un tipo de acción buscando por su id.
        /// </summary>
        /// <param name="idTipoAccion">El id del tipo de acción.</param>
        /// <returns>El tipo de acción buscado.</returns>
        public TipoDeAccionData GetIdTipoAccion(int idTipoAccion)
        {
            try
            {
                List<TipoDeAccionData> t = new List<TipoDeAccionData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from tipos in bd.TipoDeAccion
                                where tipos.idTipoAccion == idTipoAccion
                                select new TipoDeAccionData()
                                {
                                    idTipoAccion = tipos.idTipoAccion,
                                    descripcion = tipos.descripcion
                                };
                    t = datos.ToList();
                }
                if (t.Count == 0) return null;
                else return t.First();
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

        /// <summary>
        /// Devuelve un listado con todos los tipos de acciones existentes.
        /// </summary>
        /// <returns>El listado de acciones existentes.</returns>
        public List<TipoDeAccionData> GetAllTipoAccion()
        {
            try
            {
                List<TipoDeAccionData> listado = new List<TipoDeAccionData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from tipos in bd.TipoDeAccion
                                select tipos;
                    foreach (TipoDeAccion tipo in datos)
                    {
                        TipoDeAccionData tdata = new TipoDeAccionData()
                        {
                            idTipoAccion= tipo.idTipoAccion,
                            descripcion = tipo.descripcion
                        };
                        listado.Add(tdata);
                    }
                }
                return listado;
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


        /// <summary>
        /// Devuelve un listado con todos los tipos de acciones existentes.
        /// </summary>
        /// <returns>El listado de acciones existentes.</returns>
        public List<EstadoAccion> GetAllEstadoAccion()
        {
            try
            {
                List<EstadoAccion> listado = new List<EstadoAccion>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from estados in bd.EstadoDeAccion
                                select estados;
                    foreach (EstadoDeAccion tipo in datos)
                    {
                        EstadoAccion tdata = new EstadoAccion()
                        {
                            idEstadoAccion = tipo.idEstadoAccion,
                            descripcion = tipo.descripcion
                        };
                        listado.Add(tdata);
                    }
                }
                if (listado.Count == 0) return null;
                else return listado;
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


        ///// <summary>
        ///// Inserta un nuevo tipo de acción.
        ///// </summary>
        ///// <param name="tipoAccion">El tipo de acción a insertar.</param>
        ///// <returns>True si se inserta.</returns>
        //public bool AddTipoAccion(TipoDeAccionData tipoAccion)
        //{
        //    if (tipoAccion == null) return false;

        //    try
        //    {
        //        using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
        //        {
        //            TipoDeAccion tipo = new TipoDeAccion()
        //            {
        //                idTipoAccion = tipoAccion.idTipoAccion,
        //                descripcion = tipoAccion.descripcion
        //            };

        //            bd.TipoDeAccion.Add(tipo);
        //            bd.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        FaultException fault = new FaultException("ERROR SQL: " + ex.Message, new FaultCode("SQL"));
        //        throw fault;
        //    }
        //    catch (Exception ex)
        //    {
        //        FaultException fault = new FaultException("ERROR: " + ex.Message, new FaultCode("GENERAL"));
        //        throw fault;
        //    }
        //}

        ///// <summary>
        ///// Edita un tipo de acción existente.
        ///// </summary>
        ///// <param name="tipoAccion">El tipo de acción a editar.</param>
        ///// <returns>True si se ha editado.</returns>
        //public bool EditTipoAccion(TipoDeAccionData tipoAccion)
        //{
        //    if (tipoAccion == null) return false;

        //    try
        //    {
        //        using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
        //        {
        //            var data = from tipos in bd.TipoDeAccion
        //                       where tipos.idTipoAccion== tipoAccion.idTipoAccion
        //                       select tipos;

        //            TipoDeAccion t = data.First();
        //            t.descripcion = tipoAccion.descripcion;
        //            bd.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        FaultException fault = new FaultException("ERROR SQL: " + ex.Message, new FaultCode("SQL"));
        //        throw fault;
        //    }
        //    catch (Exception ex)
        //    {
        //        FaultException fault = new FaultException("ERROR: " + ex.Message, new FaultCode("GENERAL"));
        //        throw fault;
        //    }
        //}

        /*******************************************EMPRESA *****************************************/

        /// <summary>
        /// Devuelve el listado de teléfonos perteneciente a una empresa concreta
        /// </summary>
        /// <param name="idContacto">El id de la empresa cuyos teléfonos queremos obtener</param>
        /// <returns>El listado de teléfonos de una empresa</returns>
        public List<TelefonoData> GetTelefonosEmpresa(int idEmpresa)
        {
            try
            {
                List<TelefonoData> telefonos = new List<TelefonoData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var data = from empresas in bd.Empresa
                               where empresas.idEmpresa == idEmpresa
                               select empresas;

                    foreach (Telefono t in data.First().Telefono)
                    {
                        telefonos.Add(new TelefonoData()
                        {
                            idTelefono = t.idTelefono,
                            numero = t.numero
                        });
                    }

                    return telefonos;
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

        /// <summary>
        /// Devuelve el listado de contactos perteneciente a una empresa concreta
        /// </summary>
        /// <param name="idContacto">El id de la empresa cuyos contactos queremos obtener</param>
        /// <returns>El listado de contactos de una empresa</returns>
        public List<ContactoData> GetContactosEmpresa(int idEmpresa)
        {
            try
            {
                List<ContactoData> contactos = new List<ContactoData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var data = from empresas in bd.Empresa
                               where empresas.idEmpresa == idEmpresa
                               select empresas;

                    foreach (Contacto c in data.First().Contacto)
                    {
                        contactos.Add(new ContactoData()
                        {
                            idContacto = c.idContacto,
                            nif = c.nif,
                            nombre = c.nombre,
                            idEmpresa = (Int32)c.idEmpresa
                        });
                    }

                    return contactos;
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

        /******************************************* CONTACTO *****************************************/

        /// <summary>
        /// Devuelve el listado de teléfonos perteneciente a un contacto concreto
        /// </summary>
        /// <param name="idEmpresa">El id del contacto cuyos teléfonos queremos obtener</param>
        /// <returns>El listado de teléfonos de un contacto</returns>
        public List<TelefonoData> GetTelefonosContacto(int idContacto)
        {
            try
            {
                List<TelefonoData> telefonos = new List<TelefonoData>();

                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var data = from contactos in bd.Contacto
                               where contactos.idContacto == idContacto
                               select contactos;

                    foreach (Telefono t in data.First().Telefono)
                    {
                        telefonos.Add(new TelefonoData()
                        {
                            idTelefono = t.idTelefono,
                            numero = t.numero
                        });
                    }

                    return telefonos;
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

        /********************************************************************/
        /*****************************FIN IVAN*******************************/
        /********************************************************************/

        /********************************************************************/
        /*****************************MIGUEL*********************************/
        /********************************************************************/

        /// <summary>
        /// Método que añade una accion comercial a la base de datos
        /// </summary>
        /// <param name="accion"> Objeto usuario a añadir en la base de datos</param>
        /// <returns>Devuelve true si se ha añadido el registro correctamente. False si no.</returns>
        public bool addAccionComercial(AccionComercialData accion)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    AccionComercial nuevo = new AccionComercial();
                    nuevo.descripcion = accion.descripcion;
                    nuevo.comentarios = accion.comentarios;
                    nuevo.fechaHora = accion.fechaHora;
                    nuevo.idUsuario = accion.idUsuario;
                    nuevo.idTipoAccion = accion.idTipoAccion;
                    nuevo.idEstadoAccion = accion.idEstadoAccion;
                    nuevo.idEmpresa = accion.idEmpresa;

                    db.AccionComercial.Add(nuevo);
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
        /// Método que elimina un registro accion comercial de la tabla AccionComercial
        /// </summary>
        /// <param name="idAccion">identificador único de un registro accion comercial</param>
        /// <returns>Devuelve true si se ha eliminado correctamente y false si no.</returns>
        public bool deleteAccionComercial(int idAccion)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from accion in db.AccionComercial
                                   where accion.idAccion == idAccion
                                   select accion;

                    if (consulta.ToList().Count != 0)
                    {
                        AccionComercial a = consulta.First();
                        db.AccionComercial.Remove(a);
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
        /// Método que edita una accion comercial de un registro de la tabla AccionComercial
        /// </summary>
        /// <param name="idAccion">Identificador de la accion comercial a editar.</param>
        /// <param name="action">Objeto accion que contiene los datos a modificar</param>
        /// <returns>Devuelve true si se ha modificado el registro correctamente. False si no.</returns>
        public bool editAccionComercial(int idAccion, AccionComercialData accion)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from action in db.AccionComercial
                                   where action.idAccion == idAccion
                                   select action;

                    if (consulta.ToList().Count != 0)
                    {
                        AccionComercial a = consulta.First();

                        a.descripcion = accion.descripcion;
                        a.comentarios = accion.comentarios;
                        a.fechaHora = accion.fechaHora;
                        a.idUsuario = accion.idUsuario;
                        a.idTipoAccion = accion.idTipoAccion;
                        a.idEstadoAccion = accion.idEstadoAccion;
                        a.idEmpresa = accion.idEmpresa;

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
        /// Método que obtiene todas las acciones comerciales contenidos en la tabla AccionComercial
        /// </summary>
        /// <returns>Devuelve una lista de objetos AccionComercial</returns>
        public List<AccionComercialMostrarData> getAllAccionesComerciales()
        {
            List<AccionComercialMostrarData> lst = new List<AccionComercialMostrarData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from action in db.AccionComercial
                                   select action;

                    foreach (AccionComercial accion in consulta)
                    {
                        AccionComercialMostrarData a = new AccionComercialMostrarData();
                        a.idAccion = accion.idAccion;
                        a.descripcion = accion.descripcion;
                        a.comentarios = accion.comentarios;
                        a.fechaHora = accion.fechaHora;
                        a.nombreUsuario = accion.Usuario.nombre;
                        a.descripcionTipoAccion = accion.TipoDeAccion.descripcion;
                        a.descripcionEstadoAccion = accion.EstadoDeAccion.descripcion;
                        a.nombreEmpresa = accion.Empresa.nombreComercial;

                        lst.Add(a);
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
        /// Método que devuelve un registro AccionComercial concreto.
        /// </summary>
        /// <param name="idAccion"> identificador a buscar en la tabla AccionComercial.</param>
        /// <returns>Devuelve un objeto AccionComercialData.</returns>
        public AccionComercialData getAccionComercial(int idAccion)
        {
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from accion in db.AccionComercial
                                   where accion.idAccion == idAccion
                                   select new AccionComercialData()
                                   {
                                       idAccion = accion.idAccion,
                                       descripcion = accion.descripcion,
                                       comentarios = accion.comentarios,
                                       fechaHora = accion.fechaHora,
                                       idUsuario = (Int32)accion.idUsuario,
                                       idTipoAccion = (Int32)accion.idTipoAccion,
                                       idEstadoAccion = (Int32)accion.idEstadoAccion,
                                       idEmpresa = (Int32)accion.idEmpresa
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
        /********************************************************************************
         *                        getAccionesComercialesUsuarios
         *******************************************************************************/
        /// <summary>
        /// Devuelve el listado de Acciones comerciales perteneciente a un usuario concreto
        /// </summary>
        /// <param name="idUsuario">El id del usuario cuyas Acciones comerciales queremos obtener</param>
        /// <returns>El listado de acciones comerciales de un usuario</returns>
        public List<AccionComercialData> getAccionesComercialesUsuarios(int idUsuario)
        {
            List<AccionComercialData> list = new List<AccionComercialData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from usuario in db.Usuario
                                   where usuario.idUsuario == idUsuario
                                   select usuario;

                    Usuario user = consulta.First();
                    for (int i = 0; i < user.AccionComercial.Count; i++)
                    {
                        AccionComercialData nuevaAccion = new AccionComercialData();
                        nuevaAccion.idAccion = user.AccionComercial.ElementAt(i).idAccion;
                        nuevaAccion.descripcion = user.AccionComercial.ElementAt(i).descripcion;
                        nuevaAccion.comentarios = user.AccionComercial.ElementAt(i).comentarios;
                        nuevaAccion.fechaHora = user.AccionComercial.ElementAt(i).fechaHora;
                        nuevaAccion.idUsuario = (Int32)user.AccionComercial.ElementAt(i).idUsuario;
                        nuevaAccion.idTipoAccion = (Int32)user.AccionComercial.ElementAt(i).idTipoAccion;
                        nuevaAccion.idEstadoAccion = (Int32)user.AccionComercial.ElementAt(i).idEstadoAccion;
                        nuevaAccion.idEmpresa = (Int32)user.AccionComercial.ElementAt(i).idEmpresa;

                        list.Add(nuevaAccion);
                    }
                    return list;
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
        /********************************************************************************
         *                       Fin getAccionesComercialesUsuarios
         *******************************************************************************/
        /********************************************************************************
         *                        getAccionesComercialesEmpresa
         *******************************************************************************/
        /// <summary>
        /// Devuelve el listado de Acciones comerciales perteneciente a una empresa concreta
        /// </summary>
        /// <param name="idEmpresa">El id de la empresa cuyas Acciones comerciales queremos obtener</param>
        /// <returns>El listado de acciones comerciales de una empresa</returns>
        public List<AccionComercialData> getAccionesComercialesEmpresa(int idEmpresa)
        {
            List<AccionComercialData> list = new List<AccionComercialData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from empresa in db.Empresa
                                   where empresa.idEmpresa == idEmpresa
                                   select empresa;

                    Empresa emp = consulta.First();

                    for (int i = 0; i < emp.AccionComercial.Count; i++)
                    {
                        AccionComercialData nuevaAccion = new AccionComercialData();
                        nuevaAccion.idAccion = emp.AccionComercial.ElementAt(i).idAccion;
                        nuevaAccion.descripcion = emp.AccionComercial.ElementAt(i).descripcion;
                        nuevaAccion.comentarios = emp.AccionComercial.ElementAt(i).comentarios;
                        nuevaAccion.fechaHora = emp.AccionComercial.ElementAt(i).fechaHora;
                        nuevaAccion.idUsuario = (Int32)emp.AccionComercial.ElementAt(i).idUsuario;
                        nuevaAccion.idTipoAccion = (Int32)emp.AccionComercial.ElementAt(i).idTipoAccion;
                        nuevaAccion.idEstadoAccion = (Int32)emp.AccionComercial.ElementAt(i).idEstadoAccion;
                        nuevaAccion.idEmpresa = (Int32)emp.AccionComercial.ElementAt(i).idEmpresa;

                        list.Add(nuevaAccion);
                    }
                    return list;
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
        /********************************************************************************
         *                        Fin getAccionesComercialesEmpresa
         *******************************************************************************/

        /********************************************************************/
        /***************************** FIN MIGUEL****************************/
        /********************************************************************/
    }
}
