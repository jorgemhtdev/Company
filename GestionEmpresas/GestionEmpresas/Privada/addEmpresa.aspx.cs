using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblError.Visible = false;

            if (!this.IsPostBack)
            {
                try
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();

                    var sector = proxy.GetSector(); // Almaceno en sector la lista de los sectores de la BD

                    this.sector.DataSource = sector; // La fuente del DropDownList va a ser la lista de los sectores almacenadas en sector

                    this.sector.DataTextField = "descripcion"; // Nombre que tiene nuestro DropDownList sector
                    this.sector.DataValueField = "idSector"; // Valor que tiene nuestro DropDownList sector

                    this.sector.DataBind(); // Carga los valores en el DropDownList

                    this.sector.Items.Insert(0, new ListItem("Seleccione...", ""));

                }
                catch
                {
                    // this.lblError.Text = err.Message;
                    // this.alert.Visible = true; 

                    // O en sector del drownlist meter no hay datos disponibles y quitar los botones
                }
            }
        }

        protected void addEmpr(object sender, EventArgs e)
        {

            if (this.IsPostBack)
            {

                this.Validate();
                if (this.IsValid)
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();

                    try
                    {
                        //Se comprueba si hay una empresa ya con ese cif
                        EmpresaData empresa = proxy.getEmpresaCif(this.CIF.Text);

                        if (empresa == null)
                        {
                            // int addEmpresa(string cif, string nombreComercial, string razon, string web, int sector);
                            int res = proxy.addEmpresa(this.CIF.Text, this.nombreEmpresa.Text, this.RazonSocial.Text, this.paginaWeb.Text, Convert.ToInt32(this.sector.Text));

                            if (res != -1) Response.Redirect("gestionEmpresas.aspx");
                            else
                            {
                                this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                                this.lblError.Visible = true;
                            }
                        }
                        else
                        {
                            this.lblError.Text = "El Cif de la empresa ya existe. No se puede insertar en la base de datos.";
                            this.lblError.Visible = true;
                        }
                    }
                    catch (Exception err)
                    {
                        // this.lblError.Text = err.Message;
                        // this.alert.Visible = true;    
                    } // Fin del if (this.IsValid)
                }// Fin del if (this.IsPostBack)
            }
        }// Fin addEmpr


        protected void Volver(object sender, EventArgs e)
        {
            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            if (cEmp <= 0 && cCon <= 0)
            {
                Response.Redirect("gestionEmpresas.aspx", true);
            }

            if (cEmp != 0)
            {
                Response.Redirect("gestionContacto.aspx", true);
            }

            if (cCon != 0)
            {
                Response.Redirect("gestionContacto.aspx", true);
            }   
        }
    }
}
