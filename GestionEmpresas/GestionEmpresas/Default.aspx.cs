using GestionEmpresas.srvLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Entrar(object sender, AuthenticateEventArgs e)
        {
            /*//autentifica el usuario y el password con los del archivo de configuracion
            bool valido = FormsAuthentication.Authenticate(this.Login1.UserName, this.Login1.Password);

            if (valido)
            {
                FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
                e.Authenticated = true;
                Response.Redirect("privada/gestionempresas.aspx");
            }
            else
            {
                e.Authenticated = false;
                this.Login1.FailureText = "Contraseña Incorrecta";
            }*/
            ServicioLoginClient proxy = new ServicioLoginClient();
            if (proxy.esUsuario(this.Login1.UserName, this.Login1.Password))
            {
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
                Response.Redirect("privada/Default.aspx");
            }
            else
            {
                e.Authenticated = false;
                this.Login1.FailureText = "USUARIO INCORRECTO";
            }

        }
    }
}