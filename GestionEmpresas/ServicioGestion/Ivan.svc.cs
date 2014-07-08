using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServicioGestion.Model;
using System.Data.SqlClient;

namespace ServicioGestion
{
    public class Ivan : IIvan
    {
        /******************************************* TELEFONOS *****************************************/
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

        /// <summary>
        /// Permite insertar un teléfono que no exista en la base de datos. Como el teléfono está relacionado obligatoriamente con una empresa o un contacto uno de los dos parámetros será null.
        /// </summary>
        /// <param name="t">Teléfono a insertar.</param>
        /// <param name="empData">Empresa a la que pertenece el teléfono a insertar.</param>
        /// <param name="conData">Contacto al que pertenece el teléfono a insertar.</param>
        /// <returns>True si se ha insertado.</returns>
        public bool AddTelefono(TelefonoData t, EmpresaData empData, ContactoData conData)
        {
            if (t == null) return false;
            if (empData.EmpresaID == 0 && conData.idContacto == 0) return false;
            if (empData.EmpresaID != 0 && conData.idContacto != 0) return false;
            
            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    Telefono telefono = new Telefono()
                    {
                        idTelefono = t.idTelefono,
                        numero = t.numero,
                    };

                    if (empData.EmpresaID != 0)
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
                }
                return true;
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
        /// Permite editar un teléfono existente en la base de datos
        /// </summary>
        /// <param name="t">El teléfono a editar.</param>
        /// <returns>True si se ha editado.</returns>
        public bool EditTelefono(TelefonoData t)
        {
            if(t == null) return false;

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

        /******************************************* TELEFONO CONTACTO *****************************************/



        /******************************************* TIPOS DE ACCION *****************************************/

        /// <summary>
        /// Elimina un tipo de acción existente.
        /// </summary>
        /// <param name="idTipoAccion">El id del tipo de acción.</param>
        /// <returns>True si se ha eliminado.</returns>
        public bool DeleteTipoAccion(int idTipoAccion)
        {
            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var datos = from tipos in bd.TipoDeAccion
                                where tipos.idTipoAccion== idTipoAccion
                                select tipos;

                    bd.TipoDeAccion.Remove(datos.First());
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

        /// <summary>
        /// Inserta un nuevo tipo de acción.
        /// </summary>
        /// <param name="tipoAccion">El tipo de acción a insertar.</param>
        /// <returns>True si se inserta.</returns>
        public bool AddTipoAccion(TipoDeAccionData tipoAccion)
        {
            if (tipoAccion == null) return false;

            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    TipoDeAccion tipo = new TipoDeAccion()
                    {
                        idTipoAccion = tipoAccion.idTipoAccion,
                        descripcion = tipoAccion.descripcion
                    };

                    bd.TipoDeAccion.Add(tipo);
                    bd.SaveChanges();
                }
                return true;
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
        /// Edita un tipo de acción existente.
        /// </summary>
        /// <param name="tipoAccion">El tipo de acción a editar.</param>
        /// <returns>True si se ha editado.</returns>
        public bool EditTipoAccion(TipoDeAccionData tipoAccion)
        {
            if (tipoAccion == null) return false;

            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    var data = from tipos in bd.TipoDeAccion
                               where tipos.idTipoAccion== tipoAccion.idTipoAccion
                               select tipos;

                    TipoDeAccion t = data.First();
                    t.descripcion = tipoAccion.descripcion;
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
    }
}
