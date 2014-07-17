using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addEmail : System.Web.UI.Page
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

        protected void addMail(object sender, EventArgs e)
        {

        }


        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect(".aspx", true);
        }
    }
}
