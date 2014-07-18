using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addContacto : System.Web.UI.Page
    {
        /// <summary>
        ///  Usamos el Page_Load para mostrar la empresa al que vamos añadir al contacto al cargar la pagina web
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();

            // Obtemos el idEmpresa e idContacto que tenemos en la url
            int cEmp = Convert.ToInt32(Request.QueryString["id"]);

            if (cEmp != 0)
            {
                var objEmpresa = proxy.getEmpresaId(cEmp);
                this.labelContacto.Text = objEmpresa.nombreComercial;
            }
            else
            {
                this.labelContacto.Text = "Sin información";
            }
        }// Fin Page_Load

        /// <summary>
        /// EVento que nos permite agregar un contacto a la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addContac(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.Validate();

                if (this.IsValid)
                {

                    ServicioGestionClient proxy = new ServicioGestionClient();

                    /** Objeto Contacto **/

                    ContactoData objetoContacto = new ContactoData();

                    objetoContacto.nombre = this.nomb.Text;
                    objetoContacto.nif = this.nf.Text;

                    /** Fin objeto Contacto **/

                    proxy.AddContacto(objetoContacto);

                    int idEmpresa = Convert.ToInt32(Request.QueryString["id"]);
                    Response.Redirect("gestionContacto.aspx?id="+idEmpresa);

                } // Fin del if (this.IsValid)
            }// Fin del if (this.IsPostBack)
        }// Fin del addContac

        /// <summary>
        /// Evento que me lleva a la pagina gestionContacto.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Volver(object sender, EventArgs e)
        {
            int idEmpresa = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("gestionContacto.aspx?id="+idEmpresa, true);
        }//Volver
    }
}
