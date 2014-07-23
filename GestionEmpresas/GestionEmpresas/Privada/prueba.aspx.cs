using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();

            this.lblTotalAccionesComerciales.Text = Convert.ToString(proxy.numTotalAccionesComerciales()); ;
            this.lblTotalEmpresa.Text = Convert.ToString(proxy.numTotalEmpresas()); ;
            this.lblTotalContactos.Text = Convert.ToString(proxy.numTotalContactos());
            this.lblTotalUsuarios.Text = Convert.ToString(proxy.numTotalUsuarios());
        }
    }
}