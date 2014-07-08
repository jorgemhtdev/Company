
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
        /// Método que añade un email a la base de datos
        /// </summary>
        /// <param name="correo"> Correo electrónico a añadir en la base de datos</param>
        /// <returns>Devuelve true si se ha añadido el registro correctamente. False si no.</returns>
        public bool addEmail(string correo)
        {
            try
            {
                Email p = new Email();
                p.correo = correo;

                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
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
        /// <returns></returns>
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
        public bool AddDireccion(DireccionData street)
        {
            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    Direccion nueva = new Direccion();

                    nueva.idDireccion = street.idDireccion;
                    nueva.domicilio = street.domicilio;
                    nueva.poblacion = street.poblacion;
                    nueva.provincia = street.provincia;
                    nueva.codPostal = street.codPostal;

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
        ****************************  Sector ************************
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
        ***************************************************************/
    }
}
