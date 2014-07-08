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
        public List<TelefonoData> GetTelefonos()
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
        /// Permite insertar un teléfono que no exista en la base de datos.
        /// </summary>
        /// <param name="t">Teléfono a insertar.</param>
        /// <returns>True si se ha insertado.</returns>
        public bool AddTelefono(TelefonoData t)
        {
            if (t == null) return false;

            try
            {
                using (GestionEmpresasEntities bd = new GestionEmpresasEntities())
                {
                    Telefono telefono = new Telefono()
                    {
                        idTelefono = t.idTelefono,
                        numero = t.numero
                    };

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

    }
}
