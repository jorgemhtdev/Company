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
        public List<AccionComercialData> getAllAccionesComerciales()
        {
            List<AccionComercialData> lst = new List<AccionComercialData>();
            try
            {
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from action in db.AccionComercial
                                   select action;

                    foreach (AccionComercial accion in consulta)
                    {
                        AccionComercialData a = new AccionComercialData();
                        a.idAccion = accion.idAccion;
                        a.descripcion = accion.descripcion;
                        a.comentarios = accion.comentarios;
                        a.fechaHora = accion.fechaHora;
                        a.idUsuario = (Int32)accion.idUsuario;
                        a.idTipoAccion = (Int32)accion.idTipoAccion;
                        a.idEstadoAccion = (Int32)accion.idEstadoAccion;
                        a.idEmpresa = (Int32)accion.idEmpresa;

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
                    for (int i = 0; i < user.AccionComercial.Count;i++ )
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
    }
}
