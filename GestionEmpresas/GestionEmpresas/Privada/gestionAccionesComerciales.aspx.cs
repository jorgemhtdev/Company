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
    public partial class gestionAccionesComerciales : System.Web.UI.Page
    {
        public static ServicioGestionClient proxy = new ServicioGestionClient();
        public static AccionComercialMostrarData[] acciones = proxy.getAllAccionesComerciales();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    this.gvAcciones.DataSource = acciones;
                    this.gvAcciones.DataBind();
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

        protected void bAniadirContacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Privada/addAccionComercial.aspx");
        }

        protected void gvAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gvAcciones.SelectedIndex != -1)
            {
                try
                {
                    AccionComercialMostrarData accion = acciones[gvAcciones.SelectedIndex];
                    this.txtComentarios.InnerText = accion.comentarios;
                }
                catch (FaultException ex)
                {
                    /*this.lbError.Text = "Servicio " + ex.Message;
                    this.lbError.Visible = true;
                    this.lbEmpleados.Visible = false;*/

                }
                catch (Exception ex)
                {
                    /*this.lbError.Text = ex.Message;
                    this.lbError.Visible = true;
                    this.lbEmpleados.Visible = false;*/
                }
            }
        }

        protected void gvAcciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AccionComercialMostrarData accion = acciones[e.RowIndex];
            proxy.deleteAccionComercial(accion.idAccion);
            acciones = proxy.getAllAccionesComerciales();
            Response.Redirect("~/Privada/gestionAccionComercial.aspx");
        }

        protected void gvAcciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AccionComercialMostrarData accion = acciones[e.NewEditIndex];
            Response.Redirect("~/Privada/editAccionComercial.aspx?id=" + accion.idAccion);
        }
    }
}