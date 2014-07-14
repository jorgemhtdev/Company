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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();
                    var sectores = proxy.GetSector();
                    var empresas = proxy.getAllEmpresa();
                    this.gvEmpresas.DataSource = empresas;
                    this.gvEmpresas.DataBind();
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
        protected void gvEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gvEmpresas.SelectedIndex != -1)
            {
                try
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();
                    var empresas = proxy.getAllEmpresa();
                    EmpresaData emp = empresas[gvEmpresas.SelectedIndex];

                    var telefonos = proxy.GetTelefonosEmpresa(emp.EmpresaID);
                    this.gvTelefonos.DataSource = telefonos;
                    this.gvTelefonos.DataBind();

                    var emails = proxy.getMailEmpresa(emp.EmpresaID);
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
    }
}