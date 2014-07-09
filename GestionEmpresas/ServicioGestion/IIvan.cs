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
        /******************************************* TELEFONOS *********************************************/

        //Método que busca un teléfono por su número
        [OperationContract]
        TelefonoData GetNumeroTelefono(string telefono);

        //Método que busca un teléfono por su id
        [OperationContract]
        TelefonoData GetIdTelefono(int idTelefono);

        //Método que obtiene un listado de teléfonos existentes
        [OperationContract]
        List<TelefonoData> GetAllTelefonos();

        //Método que inserta un teléfono nuevo
        [OperationContract]
        bool AddTelefono(TelefonoData t, EmpresaData empData, ContactoData conData);

        //Método que edita un teléfono existente
        [OperationContract]
        bool EditTelefono(TelefonoData t);

        //Método que elimina un teléfono existente
        [OperationContract]
        bool DeleteTelefono(int idTelefono);

        /******************************************* TIPO DE ACCIÓN ********************************************/

        //Método que busca un tipo de acción por su id
        [OperationContract]
        TipoDeAccionData GetIdTipoAccion(int idTipoAccion);

        //Método que obtiene un listado de los tipos de acciones existentes
        [OperationContract]
        List<TipoDeAccionData> GetAllTipoAccion();

        //Método que inserta un nuevo tipo de acción
        [OperationContract]
        bool AddTipoAccion(TipoDeAccionData tipoAccion);

        //Método que edita un tipo de acción existente
        [OperationContract]
        bool EditTipoAccion(TipoDeAccionData tipoAccion);

        //Método que elimina un tipo de acción existente
        [OperationContract]
        bool DeleteTipoAccion(int idTipoAccion);

        /******************************************* EMPRESA ********************************************/

        [OperationContract]
        List<TelefonoData> GetTelefonosEmpresa(int idEmpresa);
        [OperationContract]
        List<ContactoData> GetContactosEmpresa(int idEmpresa);

        /******************************************* CONTACTO ********************************************/

        [OperationContract]
        List<TelefonoData> GetTelefonosContacto(int idContacto);
    }

    [DataContract]
    public class TelefonoData
    {
        [DataMember]
        public int idTelefono;
        [DataMember]
        public string numero;
    }

    [DataContract]
    public class TipoDeAccionData
    {
        [DataMember]
        public int idTipoAccion;
        [DataMember]
        public string descripcion;
    }
}
