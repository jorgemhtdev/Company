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
        public static AccionComercialMostrarData[] acciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gvAcciones.Visible = false;
                this.panel.Visible = false;

                TipoDeAccionData[] tipos = proxy.GetAllTipoAccion();
                EstadoAccion[] estados = proxy.GetEstadoAccion();

                ListItem seleccione = new ListItem("Seleccione...", "");

                this.txtTipo.DataSource = tipos;
                this.txtTipo.DataTextField = "descripcion";
                this.txtTipo.DataValueField = "descripcion";
                this.txtTipo.DataBind();
                this.txtTipo.Items.Insert(0,seleccione);

                this.txtEstado.DataSource = estados;
                this.txtEstado.DataTextField = "descripcion";
                this.txtEstado.DataValueField = "descripcion";
                this.txtEstado.DataBind();
                this.txtEstado.Items.Insert(0, seleccione);
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
                    this.gvAcciones.Visible = true;
                    this.panel.Visible = true;
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
            Response.Redirect("~/Privada/gestionAccionComercial.aspx");
        }

        protected void gvAcciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AccionComercialMostrarData accion = acciones[e.NewEditIndex];
            Response.Redirect("~/Privada/editAccionComercial.aspx?id=" + accion.idAccion);
        }

        protected void bBusqueda_Click(object sender, EventArgs e)
        {
            string sTipo = null, sEstado = null, sNombreEmpresa = null, sLoginUsuario = null;
            if(this.txtTipo.Text != "")
            {
                sTipo = this.txtTipo.Text;
            }
            if (this.txtEstado.Text != "")
            {
                sEstado = this.txtEstado.Text;
            }
            if (this.txtNombreEmpresa.Text != "")
            {
                sNombreEmpresa = this.txtNombreEmpresa.Text;
            }
            if (this.txtLogin.Text != "")
            {
                sLoginUsuario = this.txtLogin.Text;
            }
            this.gvAcciones.Visible = true;
            this.panel.Visible = true;
            acciones = proxy.filtrosAccionComercial(sTipo, sEstado, sNombreEmpresa, sLoginUsuario);
            this.gvAcciones.DataSource = acciones;
            this.gvAcciones.DataBind();
        }
    }
}