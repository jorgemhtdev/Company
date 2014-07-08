using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioGestion
{
    [ServiceContract]
    public interface IJorge
    {
        [OperationContract]
        bool AddDireccion(DireccionData street);
        [OperationContract]
        bool DeleteDireccion(DireccionData street, int id);
        [OperationContract]
        bool EditDireccion(DireccionData street, int id);
        [OperationContract]
        List<DireccionData> GetDireccion();
    }

    [DataContract]
    public class DireccionData
    {
        [DataMember]
        public int idDireccion;
        [DataMember]
        public string domicilio;
        [DataMember]
        public string poblacion;
        [DataMember]
        public string codPostal;
        [DataMember]
        public string provincia;
    }
}
