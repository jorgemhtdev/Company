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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Luismi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Luismi.svc or Luismi.svc.cs at the Solution Explorer and start debugging.
    public class Luismi : ILuismi
    {
      
       
     /*  
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
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO AÑADIR EMAIL"));
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

                    if (consult.ToList().Count != 0)
                    {
                        Email email = consult.First();

                        db.Email.Remove(email);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;
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

                    if (consult.ToList().Count != 0)
                    {
                        Email mailMod = consult.First();

                        mailMod.correo = correo;
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
                FaultException fault = new FaultException("EError SQL" + ex.Message, new FaultCode("SQL"));

                throw fault;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message, new FaultCode("ERROR SERVICIO LISTADO DE EMAILS"));
            }
        }
        */

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
                            cif = em.cif,
                            nombreComercial = em.nombreComercial,
                            razonSocial=em.razonSocial,
                            web=em.web,
                            sector=(int)em.idSector
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
                            razonSocial=em.razonSocial,
                            web=em.web,
                            sector = (int)em.idSector
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
                            EmpresaID=em.idEmpresa,
                            cif = em.cif,
                            nombreComercial = em.nombreComercial,
                            razonSocial = em.razonSocial,
                            web = em.web,
                            sector = (int)em.idSector
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
    }
}
