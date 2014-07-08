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
    public class Jorge : IJorge
    {
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
        }
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
        }
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
        }

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
                    }else{
                        return lst;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("Error en acceso a datos. " + ex.Message);
            }
        }

    }// Fin de la clase
}// Fin del servicio
