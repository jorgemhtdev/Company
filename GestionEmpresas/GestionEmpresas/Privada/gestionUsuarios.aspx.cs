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
        public static UsuarioData[] usuarios = proxy.getAllUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarios = proxy.getAllUsuarios();
            if (!this.IsPostBack)
            {
                try
                {
                    this.gvUsuarios.DataSource = usuarios;
                    this.gvUsuarios.DataBind();
                }
                catch (FaultException ex)
                {
                    /*this.lbError.Text = "Servicio " + ex.Message;
                    this.lbError.Visible = true;
                    this.lbRegiones.Visible = false;*/

                }
                catch (Exception ex)
                {
                    /*this.lbError.Text = ex.Message;
                     this.lbError.Visible = true;
                     this.lbRegiones.Visible = false;*/
                }
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
            usuarios = proxy.getAllUsuarios();
            Response.Redirect("~/Privada/gestionUsuarios.aspx");
        }

        protected void bAniadirUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Privada/addUsuario.aspx");
        }
    }
}