using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class editEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServicioGestionClient proxy = new ServicioGestionClient();

                int id = Convert.ToInt32(Request.QueryString["id"]);

                var sector = proxy.GetSector();        // Almaceno en sector la lista de los sectores de la BD
                var empresa = proxy.getEmpresaId(id);  // Almaceno en empresa la lista de los sectores de la BD

                this.labelEmpresa.Text = empresa.nombreComercial;
                
                /*** Campos a rellenas en los input **/
                this.nombreEmpresa.Text = empresa.nombreComercial;
                this.RazonSocial.Text = empresa.razonSocial;
                this.CIF.Text = empresa.cif;
                this.paginaWeb.Text = empresa.web;
                
                int isector=0;

                for(int x=0; x<sector.Count(); x++){
                    if(empresa.sector.Equals(sector[x].descripcion)){
                        isector = sector[x].idSector;
                    }
                }

                this.sector.DataSource = sector; // La fuente del DropDownList va a ser la lista de los sectores almacenadas en sector
                this.sector.SelectedIndex = isector-1;
                this.sector.DataTextField = "descripcion"; // Nombre que tiene nuestro DropDownList sector
                this.sector.DataValueField = "idSector"; // Valor que tiene nuestro DropDownList sector

                this.sector.DataBind(); // Carga los valores en el DropDownList

                /*** Fin de los campos a rellenas en los input **/
            }
            else
            {

            }
        }

        protected void editEmpr(object sender, EventArgs e)
        {

            if (this.IsPostBack)
            {

                this.Validate();
                if (this.IsValid)
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();

                    try
                    {
                        // int addEmpresa(string cif, string nombreComercial, string razon, string web, int sector);
                        int idEmpresa = Convert.ToInt32(Request.QueryString["id"]);
                        bool res = proxy.editEmpresa(idEmpresa, this.CIF.Text, this.nombreEmpresa.Text, this.RazonSocial.Text, this.paginaWeb.Text, Convert.ToInt32(this.sector.Text));

                        if (res != false) Response.Redirect("gestionEmpresas.aspx");
                        else
                        {
                            //this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                            //this.alert.Visible = true;
                        }
                    }
                    catch (Exception err)
                    {
                        // this.lblError.Text = err.Message;
                        // this.alert.Visible = true;    
                    } // Fin del if (this.IsValid)
                }// Fin del if (this.IsPostBack)
            }
        }


        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect("gestionEmpresas.aspx", true);
        }
    }
}
