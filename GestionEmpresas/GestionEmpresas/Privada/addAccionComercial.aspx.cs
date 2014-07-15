using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addAccionComercial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {

            }
        }

        protected void addAC(object sender, EventArgs e)
        {

            if (this.IsPostBack)
            {
                this.Validate();
                if (this.IsValid)
                {
                    Response.Redirect(".aspx");
                }// Fin del if
            }// Fin del if
        }


        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect(".aspx", true);
        }
    }
}
