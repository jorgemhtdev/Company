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
    public partial class gestionEmpresas : System.Web.UI.Page
    {
        public static ServicioGestionClient proxy = new ServicioGestionClient();
        public static EmpresaData[] empresas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gvEmpresas.Visible = false;
                this.panel.Visible = false;
                gvEmpresas.DataSource = empresas;
                gvEmpresas.DataBind();

                SectorData[] sectores = proxy.GetSector();
                this.txtSector.DataSource = sectores;
                this.txtSector.DataTextField = "descripcion";
                this.txtSector.DataValueField = "descripcion";
                this.txtSector.DataBind();
                this.txtSector.Items.Insert(0, new ListItem("Seleccione...", ""));

                
            }
            
        }
        protected void gvEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gvEmpresas.SelectedIndex != -1)
            {
                try
                {
                    this.gvEmpresas.Visible = true;
                    this.panel.Visible = true;
                    EmpresaData emp = empresas[gvEmpresas.SelectedIndex];

                    var telefonos = proxy.GetTelefonosEmpresa(emp.EmpresaID);
                    this.gvTelefonos.DataSource = telefonos;
                    this.gvTelefonos.DataBind();

                    var emails = proxy.getEmailEmpresa(emp.EmpresaID);
                    this.gvEmails.DataSource = emails;
                    this.gvEmails.DataBind();

                    var direcciones = proxy.getDirecionesEmpresa(emp.EmpresaID);
                    this.gvDirecciones.DataSource = direcciones;
                    this.gvDirecciones.DataBind();
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

        protected void bAniadirEmpresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Privada/addEmpresa.aspx");
        }

        protected void btnAddTelefono_Click(object sender, EventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            Response.Redirect("~/Privada/addTelefono.aspx?Empresa=" + emp.EmpresaID +"&Contacto=" + 0);
        }

        protected void btnAddEmail_Click(object sender, EventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            Response.Redirect("~/Privada/addEmail.aspx?Empresa=" + emp.EmpresaID + "&Contacto=" + 0);
        }

        protected void btnAddDireccion_Click(object sender, EventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            Response.Redirect("~/Privada/addDireccion.aspx?Empresa=" + emp.EmpresaID + "&Contacto=" + 0);
        }

        protected void gvEmpresas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "contactos")
            {
                EmpresaData emp = empresas[Convert.ToInt32(e.CommandArgument)];
                Response.Redirect("~/Privada/gestionContacto.aspx?id=" + emp.EmpresaID);
            }
        }
        protected void gvEmpresas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmpresaData emp = empresas[e.RowIndex];
            proxy.deleteEmpresa(emp.EmpresaID);
            Response.Redirect("~/Privada/gestionEmpresas.aspx");
        }

        protected void gvEmpresas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmpresaData emp = empresas[e.NewEditIndex];
            Response.Redirect("~/Privada/editEmpresa.aspx?id=" + emp.EmpresaID);
        }

        protected void gvTelefonos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            var telefonos = proxy.GetTelefonosEmpresa(emp.EmpresaID);
            TelefonoData tel = telefonos[e.RowIndex];
            proxy.DeleteTelefono(tel.idTelefono);
            Response.Redirect("~/Privada/gestionEmpresas.aspx");
        }

        protected void gvTelefonos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            var telefonos = proxy.GetTelefonosEmpresa(emp.EmpresaID);
            TelefonoData tel = telefonos[e.NewEditIndex];
            Response.Redirect("~/Privada/editTelefono.aspx?id=" + tel.idTelefono +"&Empresa=" + emp.EmpresaID +"&Contacto=" + 0);
        }

        protected void gvEmails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            var emails = proxy.getEmailEmpresa(emp.EmpresaID);
            EmailData em = emails[e.RowIndex];
            proxy.deleteEmail(em.EmailID);
            Response.Redirect("~/Privada/gestionEmpresas.aspx");
        }

        protected void gvEmails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            var emails = proxy.getEmailEmpresa(emp.EmpresaID);
            EmailData em = emails[e.NewEditIndex];
            Response.Redirect("~/Privada/editEmail.aspx?id=" + em.EmailID + "&Empresa=" + emp.EmpresaID + "&Contacto=" + 0);
        }
        protected void gvDirecciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            var direcciones = proxy.getDirecionesEmpresa(emp.EmpresaID);
            DireccionData dir = direcciones[e.RowIndex];
            proxy.DeleteDireccion(dir.idDireccion);
            Response.Redirect("~/Privada/gestionEmpresas.aspx");
        }

        protected void gvDirecciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmpresaData emp = empresas[gvEmpresas.SelectedIndex];
            var direcciones = proxy.getDirecionesEmpresa(emp.EmpresaID);
            DireccionData dir = direcciones[e.NewEditIndex];
            Response.Redirect("~/Privada/editDireccion.aspx?id=" + dir.idDireccion + "&Empresa=" + emp.EmpresaID + "&Contacto=" + 0);
        }

        protected void bBusqueda_Click(object sender, EventArgs e)
        {
            string sCif = null, sSector = null, sProvincia = null, sNombre = null;
            if(this.txtCif.Text != "")
            {
                sCif = this.txtCif.Text;
            }
            if(this.txtSector.Text != "")
            {
                sSector = this.txtSector.Text;
            }
            if (this.txtProvincia.Text != "")
            {
                sProvincia = this.txtProvincia.Text;
            }
            if (this.txtNombre.Text != "")
            {
                sNombre = this.txtNombre.Text;
            }
            this.gvEmpresas.Visible = true;
            empresas = proxy.filtrosEmpresa(sCif, sSector, sProvincia, sNombre);
            this.gvEmpresas.DataSource = empresas;
            this.gvEmpresas.DataBind();
        }
    }
}