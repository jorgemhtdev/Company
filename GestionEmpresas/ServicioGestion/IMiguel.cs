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
}
