using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class editEmail : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // El label visible a false
                // this.lblError.Visible = false;

                ServicioGestionClient proxy = new ServicioGestionClient();

                // Obtemos el id del telefono
                int id = Convert.ToInt32(Request.QueryString["id"]);

                var emailComun = proxy.getEmailId(id);

                this.labelmail.Text = emailComun.Correo;

                this.mail.Text = emailComun.Correo; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void editMail(object sender, EventArgs e)
        {
            {
                if (this.IsPostBack)
                {
                    this.Validate();
                    if (this.IsValid)
                    {
                        try
                        {
                            ServicioGestionClient proxy = new ServicioGestionClient();

                            int id = Convert.ToInt32(Request.QueryString["id"]);

                            if (id != 0)
                            {
                                // Obtengo el objeto empresa
                                var email = proxy.getEmailId(id);

                                if (email != null)
                                {
                                    bool res = proxy.editEmail(id,this.mail.Text);

                                    if (res != false)
                                    {
                                        Response.Redirect("Default.aspx");
                                    }
                                }
                                else
                                {
                                    /*this.lblError.Visible = true;
                                    this.lblError.Text = "No se puede añadir este registro. El email ya existe en la base de datos.";*/
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            // this.lblError.Text = err.Message;
                            // this.alert.Visible = true;    
                        }
                    } // Fin del if (this.IsValid)
                }// Fin del if (this.IsPostBack)
            }// Fin del addMail
        }


        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }
    }
}
