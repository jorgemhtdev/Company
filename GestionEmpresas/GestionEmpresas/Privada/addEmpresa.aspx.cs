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

            if (!IsPostBack)
            {
                try
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();

                    var sector = proxy.GetSector();

                    this.sector.DataSource = sector;

                    this.sector.DataTextField = "descripcion"; // Nombre que tiene nuestro DropDownList sector
                    this.sector.DataValueField = "idSector"; // Valor que tiene nuestro DropDownList sector
                
                    this.sector.DataBind();

                }catch{
                    // this.lblError.Text = err.Message;
                    // this.alert.Visible = true; 

                    // O en sector del drownlist meter no hay datos disponibles y quitar los botones
                }
            }
            else
            {

            }
        }

        protected void addEmpr(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();

            try
            {
                // bool addEmpresa(string cif, string nombreComercial, string razon, string web, int sector);
                proxy.addEmpresa(this.CIF.Text, this.nombreEmpresa.Text, this.RazonSocial.Text,this.paginaWeb.Text, Convert.ToInt32(this.sector.Text));
                if (res != -1) Response.Redirect("Default.aspx");
                else
                {
                    /*this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                    this.alert.Visible = true;*/

                }
            }
            catch (Exception err)
            {
                // this.lblError.Text = err.Message;
                // this.alert.Visible = true;    
            }
            
        }// Fin addEmpr


        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect(".aspx", true);
        }
    }
}
