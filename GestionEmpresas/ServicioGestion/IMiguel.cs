using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioGestion
{
    [ServiceContract]
    public interface IMiguel
    {
       /* [OperationContract]
        bool addUsuario(UsuarioData usuario);

        [OperationContract]
        bool deleteUsuario(int idUsuario);

        [OperationContract]
        bool editUsuario(int idUsuario, UsuarioData user);

        [OperationContract]
        List<UsuarioData> getAllUsuarios();

        [OperationContract]
        UsuarioData getUsuario(int idUsuario);*/

        //[OperationContract]
        //bool addAccionComercial(AccionComercialData accion);

        //[OperationContract]
        //bool deleteAccionComercial(int idAccion);

        //[OperationContract]
        //bool editAccionComercial(int idAccion, AccionComercialData accion);

        //[OperationContract]
        //List<AccionComercialData> getAllAccionesComerciales();

        //[OperationContract]
        //AccionComercialData getAccionComercial(int idAccion);

        //[OperationContract]
        //List<AccionComercialData> getAccionesComercialesUsuarios(int idUsuario);

        //[OperationContract]
        //List<AccionComercialData> getAccionesComercialesEmpresa(int idEmpresa);
    }

   /* [DataContract]
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
    }*/
    //[DataContract]
    //public class AccionComercialData
    //{
    //    [DataMember]
    //    public int idAccion;

    //    [DataMember]
    //    public string descripcion;

    //    [DataMember]
    //    public string comentarios;

    //    [DataMember]
    //    public DateTime fechaHora;

    //    [DataMember]
    //    public int idUsuario;

    //    [DataMember]
    //    public int idTipoAccion;

    //    [DataMember]
    //    public int idEstadoAccion;

    //    [DataMember]
    //    public int idEmpresa;
    //}
}
