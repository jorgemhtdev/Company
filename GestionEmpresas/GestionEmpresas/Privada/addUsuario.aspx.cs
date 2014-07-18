using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento del boton que me añade un usuario a la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addUser(object sender, EventArgs e)
        {
            if (this.IsPostBack){

                this.Validate();
                
                if (this.IsValid)  {

                ServicioGestionClient proxy = new ServicioGestionClient();

                /** Objeto Usuario **/

                UsuarioData objetoUsuario = new UsuarioData();

                objetoUsuario.login = this.login.Text;
                objetoUsuario.nombre = this.nombre.Text;
                objetoUsuario.password = this.pass.Text;

                /** Fin objeto Usuario **/

                proxy.addUsuario(objetoUsuario);

                Response.Redirect("gestionUsuarios.aspx");

                }// Fin del if
            }// Fin del if
        }// Fin del addUser

        /// <summary>
        /// Evento que me lleva a la pagina gestionUsuarios.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect("gestionUsuarios.aspx", true);
        }// Fin del protected void Volver
    }
}
