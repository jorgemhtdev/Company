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
    public partial class gestionContacto : System.Web.UI.Page
    {
        public static ServicioGestionClient proxy = new ServicioGestionClient();
        public static int idEmpresa = Convert.ToInt32(HttpContext.Current.Request.QueryString["id"]);
        public static ContactoData[] contactos = proxy.GetContactosEmpresa(idEmpresa);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    this.panel.Visible = false;
                    this.gvContactos.DataSource = contactos;
                    this.gvContactos.DataBind();
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
        protected void gvContactos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gvContactos.SelectedIndex != -1)
            {
                try
                {
                    this.panel.Visible = true;
                    ContactoData cont = contactos[gvContactos.SelectedIndex];

                    var telefonos = proxy.GetTelefonosContacto(cont.idContacto);
                    this.gvTelefonos.DataSource = telefonos;
                    this.gvTelefonos.DataBind();

                    var emails = proxy.getEmailContacto(cont.idContacto);
                    this.gvEmails.DataSource = emails;
                    this.gvEmails.DataBind();

                    var direcciones = proxy.getDirecionesContacto(cont.idContacto);
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

        protected void bAniadirContacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Privada/addContacto.aspx?id="+ idEmpresa);
        }

        protected void btnAddTelefono_Click(object sender, EventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            Response.Redirect("~/Privada/addTelefono.aspx?Empresa=" + 0 + "&Contacto=" + cont.idContacto);
        }

        protected void btnAddEmail_Click(object sender, EventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            Response.Redirect("~/Privada/addEmail.aspx?Empresa=" + 0 + "&Contacto=" + cont.idContacto);
        }

        protected void btnAddDireccion_Click(object sender, EventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            Response.Redirect("~/Privada/addDireccion.aspx?Empresa=" + 0 + "&Contacto=" + cont.idContacto);
        }

        protected void gvContactos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ContactoData cont = contactos[e.RowIndex];
            proxy.DeleteContacto(cont, cont.idContacto);
            Response.Redirect("~/Privada/gestionContacto.aspx?id="+idEmpresa);
        }

        protected void gvContactos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ContactoData cont = contactos[e.NewEditIndex];
            Response.Redirect("~/Privada/editEmpresa.aspx?id=" + cont.idContacto);
        }

        protected void gvTelefonos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            var telefonos = proxy.GetTelefonosContacto(cont.idContacto);
            TelefonoData tel = telefonos[e.RowIndex];
            proxy.DeleteTelefono(tel.idTelefono);
            Response.Redirect("~/Privada/gestionContacto.aspx?id=" + idEmpresa);
        }

        protected void gvTelefonos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            var telefonos = proxy.GetTelefonosContacto(cont.idContacto);
            TelefonoData tel = telefonos[e.NewEditIndex];
            Response.Redirect("~/Privada/editTelefono.aspx?id=" + tel.idTelefono);
        }

        protected void gvEmails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            var emails = proxy.getEmailContacto(cont.idContacto);
            EmailData em = emails[e.RowIndex];
            proxy.deleteEmail(em.EmailID);
            Response.Redirect("~/Privada/gestionContacto.aspx?id=" + idEmpresa);
        }

        protected void gvEmails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            var emails = proxy.getEmailContacto(cont.idContacto);
            EmailData em = emails[e.NewEditIndex];
            Response.Redirect("~/Privada/editEmail.aspx?id=" + em.EmailID);
        }
        protected void gvDirecciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            var direcciones = proxy.getDirecionesContacto(cont.idContacto);
            DireccionData dir = direcciones[e.RowIndex];
            proxy.DeleteDireccion(dir.idDireccion);
            Response.Redirect("~/Privada/gestionContacto.aspx?id=" + idEmpresa);
        }

        protected void gvDirecciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ContactoData cont = contactos[gvContactos.SelectedIndex];
            var direcciones = proxy.getDirecionesContacto(cont.idContacto);
            DireccionData dir = direcciones[e.NewEditIndex];
            Response.Redirect("~/Privada/editEmail.aspx?id=" + dir.idDireccion);
        }
    }
}