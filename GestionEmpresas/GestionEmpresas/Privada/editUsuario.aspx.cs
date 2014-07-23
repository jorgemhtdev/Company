using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class editUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ServicioGestionClient proxy = new ServicioGestionClient();
            
            var user = proxy.getUsuario(id);

            this.login.Text = user.login;
            this.nombre.Text = user.nombre;
            this.pass.Text = user.password;
            this.rpass.Text = user.password;
            
            //this.lblError.Visible = false;

        }

        /// <summary>
        /// Evento del boton que me añade un usuario a la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditarUser(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {

                this.Validate();

                if (this.IsValid)
                {

                    ServicioGestionClient proxy = new ServicioGestionClient();

                    /** Objeto Usuario **/

                    UsuarioData objetoUsuario = new UsuarioData();

                    objetoUsuario.login = this.login.Text;
                    objetoUsuario.nombre = this.nombre.Text;
                    objetoUsuario.password = this.pass.Text;
                    objetoUsuario.idUsuario = Convert.ToInt32(Request.QueryString["id"]);

                    /** Fin objeto Usuario **/

                    //Se comprueba que el login no este ya en la base de datos.
                    UsuarioData usuario = proxy.getUsuarioLogin(objetoUsuario.login);

                    //Si no está en la bd, se añade.
                    if (usuario.idUsuario != 0)
                    {
                        proxy.addUsuario(objetoUsuario);
                        Response.Redirect("gestionUsuarios.aspx");
                    }/*
                    else
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = "El login del usuario ya existe en la base de datos. Intente agregar otro usuario con un login distinto.";
                    }*/

                } // Fin del if (this.IsValid)
            }// Fin del if (this.IsPostBack)
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

