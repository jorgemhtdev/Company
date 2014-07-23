using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class gestionUsuarios : System.Web.UI.Page
    {
        public static ServicioGestionClient proxy = new ServicioGestionClient();
        public static UsuarioData[] usuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                usuarios = proxy.getAllUsuarios();
                this.gvUsuarios.DataSource = usuarios;
                this.gvUsuarios.DataBind();
            }
        }

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UsuarioData user = usuarios[e.NewEditIndex];
            Response.Redirect("~/Privada/editUsuario.aspx?id=" + user.idUsuario);
        }

        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            UsuarioData user = usuarios[e.RowIndex];
            proxy.deleteUsuario(user.idUsuario);
            Response.Redirect("~/Privada/gestionUsuarios.aspx");
        }

        protected void bAniadirUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Privada/addUsuario.aspx");
        }

        protected void bBusqueda_Click(object sender, EventArgs e)
        {
            string sLogin = null, sNombre = null;
            if (this.txtLogin.Text != "")
            {
                sLogin = this.txtLogin.Text;
            }
            if (this.txtNombre.Text != "")
            {
                sNombre = this.txtNombre.Text;
            }
            usuarios = proxy.filtrosUsuario(sLogin, sNombre);
            this.gvUsuarios.DataSource = usuarios;
            this.gvUsuarios.DataBind();
        }
    }
}