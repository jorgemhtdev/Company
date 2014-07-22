using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class editTelefono : System.Web.UI.Page
    {
        /// <summary>
        /// Usamos el Page_Load para mostrar la empresa o el contacto al que vamos añadir el telefono al cargar la pagina web
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //El label visible a false
                this.lblError.Visible = false;

                ServicioGestionClient proxy = new ServicioGestionClient();

                // Obtemos el id del telefono
                int id = Convert.ToInt32(Request.QueryString["id"]);

                var telefonoComun = proxy.GetIdTelefono(id);

                this.telepone.Text = telefonoComun.numero; 
            }

        } // Fin Page_Load

        /// <summary>
        /// Evento del boton que añade los input a nuestra BD. Los datos recogidos creamos un objeto Telefono, despues debemos de tener en cuenta si es para una empresa o 
        /// para un contacto. Para ello utilizamos el request QueryString que nos recoge dos numeros, uno que nos dan por el formulario y otro que es un cero.
        /// Si es cero, no realizamos ninguna operación y operamos sobre el numero !=0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addTlf(object sender, EventArgs e)
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
                            TelefonoData t = new TelefonoData();

                            t.idTelefono = Convert.ToInt32(id); 
                            t.numero = this.telepone.Text;

                            if (t != null)
                            {
                                proxy.EditTelefono(t);
                                Response.Redirect("Default.aspx");
                            }
                            else
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "No se puede añadir este registro. El número de teléfono ya existe en la base de datos.";
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = err.Message;    
                    }
                } // Fin del if (this.IsValid)
            }// Fin del if (this.IsPostBack)
        } // Fin del addTlf

        /// <summary>
        /// Evento que nos devuelve a la pagina donde volvimos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Volver(object sender, EventArgs e)
        {  
            Response.Redirect("Default.aspx", true);
        }// Fin del protected void Volver
    }
}
