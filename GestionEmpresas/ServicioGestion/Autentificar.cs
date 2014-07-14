using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using ServicioGestion.Model;
using System.ServiceModel;

namespace ServicioGestion
{
    public class Autentificar : UserNamePasswordValidator
    {
        //dice si un usuario es valido o no. El validate viene prefijado con esos argumentos.
        //Cada evz que alguien me pida algo en el servicio
        public override void Validate(string login, string password)
        {
            try
            {
                GestionEmpresasEntities db = new GestionEmpresasEntities();
                var usr = from usuarios in db.Usuario
                          where usuarios.login == login
                          select usuarios;
                Usuario usu = usr.First();
                db.Dispose();

                if (usu != null && usu.password == password)
                {

                }
                else
                {
                    throw new FaultException("ERROR USUARIO NO AUTORIZADO");
                }
            }
            catch
            {
                throw new FaultException("ERROR USUARIO NO AUTORIZADO");
            }
        }
    }
}