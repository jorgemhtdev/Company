using ServicioGestion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioGestion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILuismi" in both code and config file together.
    [ServiceContract]
    public interface ILuismi
    {
        ////////////////////EMAIL
        /*
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
         * */
        ////////////////////FIN EMAIL//////////////////////////////////

        ////////////////////EMPRESA///////////////////////////////////
        //Método que añade una empresa
        [OperationContract]
        bool addEmpresa(string cif, string nombreComercial, string razon, string web, int sector);

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
        List<EmailData> getMailEmpresa(int idEmpresa);

        //Método que obtiene los emails de cada empresa
        [OperationContract]
        List<EmailData> getMailContacto(int idContacto);

    }

    /*
    [DataContract]
    public class EmailData
    {
        [DataMember]
        public int EmailID;
        [DataMember]
        public string Correo;
       
    }
     * */

    /// <summary>
    /// Objeto Empresa
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
        public int sector;
    }
}
