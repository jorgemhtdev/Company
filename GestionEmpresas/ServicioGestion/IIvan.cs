using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServicioGestion.Model;

namespace ServicioGestion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIvan" in both code and config file together.
    [ServiceContract]
    public interface IIvan
    {
        [OperationContract]
        TelefonoData GetNumeroTelefono(string telefono);
        [OperationContract]
        TelefonoData GetIdTelefono(int idTelefono);
        [OperationContract]
        List<TelefonoData> GetTelefonos();
        [OperationContract]
        bool AddTelefono(TelefonoData t);
        [OperationContract]
        bool EditTelefono(TelefonoData t);
        [OperationContract]
        bool DeleteTelefono(int idTelefono);
    }

    [DataContract]
    public class TelefonoData
    {
        [DataMember]
        public int idTelefono;
        [DataMember]
        public string numero;
    }
}
