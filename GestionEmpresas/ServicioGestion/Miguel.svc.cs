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
    public class Miguel : IMiguel
    {
        /*/// <summary>
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
        /// Método que obtiene todos los emails contenidos en la tabla Email
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
        }*/
    }
}
