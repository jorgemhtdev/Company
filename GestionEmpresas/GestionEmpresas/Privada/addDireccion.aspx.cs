using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addDireccion : System.Web.UI.Page
    {
        /// <summary>
        /// Usamos el Page_Load para mostrar la empresa o el contacto al que vamos añadir la direccion al cargar la pagina web
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //El label visible a false
            this.lblError.Visible = false;

            ServicioGestionClient proxy = new ServicioGestionClient();

            // Obtemos el idEmpresa o el idContacto que nos dan por la url
            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            // Si recibimos el idEmpresa mostramos el contacto al que le vamos añadir un email
            if (cEmp != 0)
            {
                var objEmpresa = proxy.getEmpresaId(cEmp);
                this.labeldireccion.Text = objEmpresa.nombreComercial;
            }
            // Si recibimos el idContacto mostramos el contacto al que le vamos añadir un email
            if (cCon != 0)
            {
                var objContacto = proxy.getContacto(cCon);
                this.labeldireccion.Text = objContacto.nombre;
            }
            else
            {
                this.labeldireccion.Text = "-Sin informacion de empresa o contacto-";
                this.lblError.Visible = true;
                this.lblError.Text = "No se ha accedido correctamente a esta pagina web, haz click en volver y acceda correctamente";
                this.btnEnviar.Visible = false;

                this.dom.Visible = false;
                this.domici.Visible = false;
                this.pob.Visible = false;
                this.poblac.Visible = false;
                this.copo.Visible = false;
                this.cp.Visible = false;
                this.pro.Visible = false;
                this.provin.Visible = false; 

                this.lblError.CssClass = "page-header alert alert-danger";
                this.btnVolver.CssClass = "btn btn-danger btn-lg col-md-4 col-md-offset-3";
            }
        } // Fin del Page_Load
        
        /// <summary>
        /// Evento del boton que añade los input a nuestra BD. Los datos recogidos creamos un objeto DireccionData, despues debemos de tener en cuenta si es para una empresa o 
        /// para un contacto. Para ello utilizamos el request QueryString que nos recoge dos numeros, uno que nos dan por el formulario y otro que es un cero.
        /// Si es cero, no realizamos ninguna operación y operamos sobre el numero !=0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void adDireccion(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                {
                    this.Validate();

                    if (this.IsValid){
            
                    ServicioGestionClient proxy = new ServicioGestionClient();

                    // En estas dos variables almacenamos el numero del idempresa o idcontacto y un cero.
                    int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
                    int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

                    /** Objeto direccion **/

                    DireccionData objetoStreet = new DireccionData();

                    objetoStreet.domicilio = this.domici.Text;
                    objetoStreet.poblacion = this.poblac.Text;
                    objetoStreet.codPostal = this.cp.Text;
                    objetoStreet.provincia = this.provin.Text;

                    /** Fin objeto direccion **/

                    /***************************************************************************************************************************/
                    // Si la empresa es distinto a cero, procedemos a guardar los datos a la BD.
                    if (cEmp != 0)
                    {
                        // Obtengo el objeto empresa
                        var objEmpresa = proxy.getEmpresaId(cEmp);
                        proxy.AddDireccion(objetoStreet, objEmpresa, null);
                        Response.Redirect("gestionEmpresas.aspx");
                    }
                    /***************************************************************************************************************************/

                    /***************************************************************************************************************************/
                    //Si el contacto es distinto a cero, procedemos a guardar los datos a la BD.
                    if (cCon != 0)
                    {
                        var objContacto = proxy.getContacto(cCon); // Obtengo el contacto
                        proxy.AddDireccion(objetoStreet, null, objContacto);
                        var idEmpresa = objContacto.idEmpresa;
                        /****************/
                        Response.Redirect("gestionContacto.aspx?id=" + idEmpresa);
                    }

                    /***************************************************************************************************************************/

                    } // Fin del if (this.IsValid)
                }// Fin del if (this.IsPostBack)
        }// Fin del addDirec

        /// <summary>
        /// Evento que nos devuelve a la pagina donde volvimos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Volver(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();

            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            if (cEmp != 0)
            {
                Response.Redirect("gestionEmpresas.aspx", true);
            }

            if (cCon != 0)
            {
                /****************/
                var objContacto = proxy.getContacto(cCon); // Obtengo el contacto
                var idEmpresa = objContacto.idEmpresa;
                /****************/
                Response.Redirect("gestionContacto.aspx?id=" + idEmpresa);
            }
            else
            {
                Response.Redirect("Default.aspx?id=");
            }
        }// Fin del protected void Volver
    }
}
