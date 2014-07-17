using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
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
        /***********************************************************************/
        /********************LUIS MIGUEL MORALES*********************************/
        /***********************************************************************/
       
        //Método que añade un email
        [OperationContract]
        int addEmail(string correo, EmpresaData empData, ContactoData conData);

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

        ////////////////////EMPRESA///////////////////////////////////
        //Método que añade una empresa
        [OperationContract]
        int addEmpresa(string cif, string nombreComercial, string razon, string web, int sector);

        //Método que obtiene todos los registros de la tabla empresa
        [OperationContract]
        List<EmpresaData> getAllEmpresa();

        //Método que obtiene una empresa por cif
        [OperationContract]
        EmpresaData getEmpresaCif(string cif);

        //Método que obtiene una empresa por un identificador
        [OperationContract]
        EmpresaData getEmpresaId(int id);

        //Método que obtiene una empresa por un identificador
        [OperationContract]
        List<EmpresaData> getEmpresaSector(int idSector);

        //Método que elimina de la tabla Email un registro
        [OperationContract]
        bool deleteEmpresa(int idEmpresa);

        //Método que edita un registro de la tabla Empresa 
        [OperationContract]
        bool editEmpresa(int idEmpresa, string cif, string nombreComercial, string razon, string web, int sector);

        ////////////////////FIN EMPRESA///////////////////////////////////


        ///////////////////EMAIL-EMPRESA/////////////////////////////////

        //Método que obtiene los emails de cada empresa
        [OperationContract]
        List<EmailData> getEmailEmpresa(int idEmpresa);

        ///////////////////FIN EMAIL-EMPRESA/////////////////////////////////

        ///////////////////EMAIL-CONTACTO/////////////////////////////////

        //Método que obtiene los emails de cada empresa
        [OperationContract]
        List<EmailData> getEmailContacto(int idContacto);

        ///////////////////FIN EMAIL-CONTACTO/////////////////////////////////

        /***********************************************************************/
        /********************FIN LUIS MIGUEL MORALES****************************/
        /***********************************************************************/

        /***********************************************************************/
        /********************JORGE *********************************************/
        /***********************************************************************/
        /// Direccion

        [OperationContract]
        int AddDireccion(DireccionData street, EmpresaData empData, ContactoData conData);
        [OperationContract]
        bool DeleteDireccion(int id);
        [OperationContract]
        int EditDireccion(DireccionData street);
        [OperationContract]
        List<DireccionData> GetDireccion();

        /// Fin Direccion

        /// Sector
        
        [OperationContract]
        List<SectorData> GetSector();

        /// Fin sector

        /*******************************ESTADO ACCION***************************/

        /// Estado de accion

        [OperationContract]
        List<EstadoAccion> GetEstadoAccion();

        /// Fin estado de accion
        /// 
        /// Contacto

        [OperationContract]
        List<ContactoData> GetContacto();

        [OperationContract]
        bool DeleteContacto(ContactoData contacto, int id);

        [OperationContract]
        int AddContacto(ContactoData contacto);

        [OperationContract]
        int EditContacto(ContactoData contacto, int id);
   
        
        /******************* METODOS MAS COOL *******************/
        [OperationContract]
        List<DireccionData> getDirecionesEmpresa(int idEmpresa);
        [OperationContract]
        List<DireccionData> getDirecionesContacto(int idContacto);
        /******************* FIN METODOS MAS COOL *******************/

        /***********************************************************************/
        /******************** FIN JORGE ****************************************/
        /***********************************************************************/

        /***********************************************************************/
        /******************** IVÁN *********************************************/
        /***********************************************************************/

        /************************* TELEFONOS ***********************************/

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
        int AddTelefono(TelefonoData t, EmpresaData empData, ContactoData conData);

        //Método que edita un teléfono existente
        [OperationContract]
        int EditTelefono(TelefonoData t);

        //Método que elimina un teléfono existente
        [OperationContract]
        bool DeleteTelefono(int idTelefono);

        /********************** TIPO DE ACCIÓN **********************************/

        //Método que busca un tipo de acción por su id
        [OperationContract]
        TipoDeAccionData GetIdTipoAccion(int idTipoAccion);

        //Método que obtiene un listado de los tipos de acciones existentes
        [OperationContract]
        List<TipoDeAccionData> GetAllTipoAccion();

        //Método que inserta un nuevo tipo de acción
        //[OperationContract]
        //bool AddTipoAccion(TipoDeAccionData tipoAccion);

        ////Método que edita un tipo de acción existente
        //[OperationContract]
        //bool EditTipoAccion(TipoDeAccionData tipoAccion);

        ////Método que elimina un tipo de acción existente
        //[OperationContract]
        //bool DeleteTipoAccion(int idTipoAccion);

        /************************ TELEFONO EMPRESA *****************************/

        [OperationContract]
        List<TelefonoData> GetTelefonosEmpresa(int idEmpresa);
        [OperationContract]
        List<ContactoData> GetContactosEmpresa(int idEmpresa);

        /****************************TELEFONO  CONTACTO **************************/

        [OperationContract]
        List<TelefonoData> GetTelefonosContacto(int idContacto);


       

        /***********************************************************************/
        /********************FIN IVÁN ******************************************/
        /***********************************************************************/


        /***********************************************************************/
        /******************** MIGUEL********************************************/
        /***********************************************************************/
        // Usuario
        [OperationContract]
        int addUsuario(UsuarioData usuario);

        [OperationContract]
        bool deleteUsuario(int idUsuario);

        [OperationContract]
        int editUsuario(int idUsuario, UsuarioData user);

        [OperationContract]
        List<UsuarioData> getAllUsuarios();

        [OperationContract]
        UsuarioData getUsuario(int idUsuario);
        //Fin Usuario

        [OperationContract]
        int addAccionComercial(AccionComercialData accion);

        [OperationContract]
        bool deleteAccionComercial(int idAccion);

        [OperationContract]
        int editAccionComercial(AccionComercialData accion);

        [OperationContract]
        List<AccionComercialMostrarData> getAllAccionesComerciales();

        [OperationContract]
        AccionComercialData getAccionComercial(int idAccion);

        [OperationContract]
        List<AccionComercialData> getAccionesComercialesUsuarios(int idUsuario);

        [OperationContract]
        List<AccionComercialData> getAccionesComercialesEmpresa(int idEmpresa);

        /***********************************************************************/
        /********************FIN MIGUEL ****************************************/
        /***********************************************************************/
    }

    /**********CLASES  DATA***/

    /***********************************************************************/
    /********************LUIS MIGUEL****************************************/
    /***********************************************************************/

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

    /// <summary>
    /// Objeto empresa.
    /// EmpresaID= Identificador único que está asociado a una empresa
    /// cif= C.I.F. de una empresa
    /// nombreComercial= Nombre comercial de una empresa.
    /// razonSocial= Razón social de una empresa.
    /// web= Página web de una empresa.
    /// sector= Identificador del sector al que pertenece una empresa.
    /// </summary>
    public class EmpresaData
    {
        [DataMember]
        public int EmpresaID;
        [DataMember]
        public string cif;
        [DataMember]
        public string nombreComercial;
        [DataMember]
        public string razonSocial;
        [DataMember]
        public string web;
        [DataMember]
        public string sector;
    }

    /***********************************************************************/
    /********************FIN LUIS MIGUEL************************************/
    /***********************************************************************/

    /***********************************************************************/
    /**************************JORGE****************************************/
    /***********************************************************************/

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
        
    //fin Direccion

    /// Sector

    [DataContract]
    public class SectorData
    {
        [DataMember]
        public int idSector;
        [DataMember]
        public string descripcion;

    }

    //fin Sector


    /// Estado de accion

    [DataContract]
    public class EstadoAccion
    {
        [DataMember]
        public int idEstadoAccion;
        [DataMember]
        public string descripcion;
    }

    //fin estado de accion

    //Usuario
    [DataContract]
    public class UsuarioData
    {
        [DataMember]
        public int idUsuario;

        [DataMember]
        public string login;

        [DataMember]
        public string nombre;

        [DataMember]
        public string password;
    }
    //Fin Usuario

    /// Contacto
    [DataContract]
    public class ContactoData
    {
        [DataMember]
        public int idContacto;
        [DataMember]
        public string nif;
        [DataMember]
        public string nombre;
        [DataMember]
        public int idEmpresa;
    }
    /// Fin contacto

    /***********************************************************************/
    /**************************FIn JORGE************************************/
    /***********************************************************************/

    /***********************************************************************/
    /***********************IVÁN *******************************************/
    /***********************************************************************/

    //Telefono
    [DataContract]
    public class TelefonoData
    {
        [DataMember]
        public int idTelefono;
        [DataMember]
        public string numero;
    }

    //Fin Telefono

    //Tipo Acción

    [DataContract]
    public class TipoDeAccionData
    {
        [DataMember]
        public int idTipoAccion;
        [DataMember]
        public string descripcion;
    }

    //fin Tipo Acción

    /***********************************************************************/
    /********************FIN IVÁN ******************************************/
    /***********************************************************************/


    /***********************************************************************/
    /******************** MIGUEL********************************************/
    /***********************************************************************/
    [DataContract]
    public class AccionComercialData
    {
        [DataMember]
        public int idAccion;

        [DataMember]
        public string descripcion;

        [DataMember]
        public string comentarios;

        [DataMember]
        public DateTime fechaHora;

        [DataMember]
        public int idUsuario;

        [DataMember]
        public int idTipoAccion;

        [DataMember]
        public int idEstadoAccion;

        [DataMember]
        public int idEmpresa;
    }


    [DataContract]
    public class AccionComercialMostrarData
    {
        [DataMember]
        public int idAccion;

        [DataMember]
        public string descripcion;

        [DataMember]
        public string comentarios;

        [DataMember]
        public DateTime fechaHora;

        [DataMember]
        public string nombreUsuario;

        [DataMember]
        public string descripcionTipoAccion;

        [DataMember]
        public string descripcionEstadoAccion;

        [DataMember]
        public string nombreEmpresa;
    }


    /***********************************************************************/
    /********************FIN MIGUEL ****************************************/
    /***********************************************************************/
}
