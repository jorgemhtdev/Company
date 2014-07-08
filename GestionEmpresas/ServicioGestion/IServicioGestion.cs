using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioGestion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioGestion" in both code and config file together.
    [ServiceContract]
    public interface IServicioGestion
    {
        //EMAIL
       
        //Método que añade un email
        [OperationContract]
        bool addEmail(string correo);

        //Método que obtiene todos los emails
        [OperationContract]
        List<EmailData> getAllEmail();

        //Método que obtiene un email con un identificador concreto
        [OperationContract]
        EmailData getEmailId(int id);

        //Método que obtiene un email con un correo concreto
        [OperationContract]
        EmailData getEmailCorreo(string correo);

        //Método que elimina de la tabla Email un registro
        [OperationContract]
        bool deleteEmail(int idEmail);

        //Método que edita un registro de la tabla Email 
        [OperationContract]
        bool editEmail(int idEmail, string correo);

        //FIN EMAIL

        /// Direccion
       
        [OperationContract]
        bool AddDireccion(DireccionData street);
        [OperationContract]
        bool DeleteDireccion(DireccionData street, int id);
        [OperationContract]
        bool EditDireccion(DireccionData street, int id);
        [OperationContract]
        List<DireccionData> GetDireccion();

        /// Fin Direccion
    }

    
    //EMAIL
    [DataContract]
    public class EmailData
    {
        [DataMember]
        public int EmailID;
        [DataMember]
        public string Correo;

    }

    //FIN EMAIL

    /// Direccion
 
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
        
    //FIN Direccion
}
