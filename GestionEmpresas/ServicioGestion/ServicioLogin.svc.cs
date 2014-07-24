using ServicioGestion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioGestion
{
   
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioLogin.svc or ServicioLogin.svc.cs at the Solution Explorer and start debugging.
    public class ServicioLogin : IServicioLogin
    {
        public bool esUsuario(string login, string password)
        {
            bool resultado;
            try
            {
                //Using es para no tener que liberar recursos, no hacer el disposing
                using (GestionEmpresasEntities db = new GestionEmpresasEntities())
                {
                    var consulta = from usuario in db.Usuario
                                   where usuario.login == login
                                   select usuario;
                    Usuario usr = consulta.First();
                    resultado = (usr != null) && (usr.password == PasswordManager.getMD5(password));
                }
                return resultado;
            }
            catch
            {
                return false;
            }
        }

    }
}
