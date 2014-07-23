using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class editContacto : System.Web.UI.Page
    {
        /// <summary>
        ///  Usamos el Page_Load para mostrar la empresa al que vamos añadir al contacto al cargar la pagina web
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
                        if (!this.IsPostBack)
            {
            this.lblError.Visible = false;

            ServicioGestionClient proxy = new ServicioGestionClient();

            // Obtemos el idEmpresa e idContacto que tenemos en la url
            int idContacto = Convert.ToInt32(Request.QueryString["id"]);

            if (idContacto != 0)
            {
                var objContacto = proxy.getContacto(idContacto);
                var idEmpreaDelContacto = objContacto.idEmpresa;

                var empresaResultado = proxy.getEmpresaId(idEmpreaDelContacto);

                this.labelContacto.Text = empresaResultado.nombreComercial;

                var Contacto = proxy.getContacto(idContacto);

                this.nomb.Text = Contacto.nombre;

                this.nf.Text = Contacto.nif;
            }
            else
            {
                this.labelContacto.Text = "Sin información";
            }
                            }
        }// Fin Page_Load

        /// <summary>
        /// EVento que nos permite agregar un contacto a la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditarContacto(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.Validate();

                if (this.IsValid)
                {

                    ServicioGestionClient proxy = new ServicioGestionClient();

                    int idContacto = Convert.ToInt32(Request.QueryString["id"]);
                    var objContacto = proxy.getContacto(idContacto);
                    var idEmpreaDelContacto = objContacto.idEmpresa;

                    var empresaResultado = proxy.getEmpresaId(idEmpreaDelContacto);

                    /** Objeto Contacto **/

                    ContactoData objetoContacto = new ContactoData();

                    objetoContacto.nombre = this.nomb.Text;
                    objetoContacto.nif = this.nf.Text;
                    objetoContacto.idContacto = idContacto;
                    objetoContacto.idEmpresa = empresaResultado.EmpresaID;

                    /** Fin objeto Contacto **/



                        proxy.EditContacto(objetoContacto, idContacto);

                        Response.Redirect("gestionContacto.aspx?id=" + empresaResultado.EmpresaID);
                    
                    /*else
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = "No se puede insertar este contacto. El N.I.F. ya existe en la base de datos.";
                    }*/

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
            Response.Redirect("gestionContacto.aspx?id=" + idEmpresa, true);
        }//Volver
    }
}