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
            ServicioGestionClient proxy = new ServicioGestionClient();

            // Obtemos el idEmpresa e idContacto que tenemos en la url
            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            if (cEmp != 0 && cCon != 0) this.labeldireccion.Text = " - Sin informacion - ";

            if (cEmp != 0)
            {
                var objEmpresa = proxy.getEmpresaId(cEmp);
                this.labeldireccion.Text = objEmpresa.nombreComercial;
            }
            
            if (cCon != 0)
            {
                var objContacto = proxy.getContacto(cCon);
                this.labeldireccion.Text = objContacto.nombre;
            }
        } // Fin del Page_Load
        
        /// <summary>
        /// Evento del boton que añade los input a nuestra BD. Los datos recogidos creamos un objeto DireccionData, despues debemos de tener en cuenta si es para una empresa o 
        /// para un contacto. Para ello utilizamos el request QueryString que nos recoge dos numeros, uno que nos dan por el formulario y otro que es un cero.
        /// Si es cero, no realizamos ninguna operación y operamos sobre el numero !=0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addDirec(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                {
                    this.Validate();

                    if (this.IsValid){
            
                    ServicioGestionClient proxy = new ServicioGestionClient();

                    // En estas dos variables almacenamos el numero del idempresa o idcontacto y un cero.
                    int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
                    int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);
                    int res = -1; // Inicializamos el resultado a valor -1

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
                        res = proxy.AddDireccion(objetoStreet, objEmpresa, null);
                    }

                    //Si el contacto es distinto a cero, procedemos a guardar los datos a la BD.
                    if (cCon != 0)
                    {
                        // Obtengo el objeto contacto
                        var objContacto = proxy.getContacto(cCon);
                        res = proxy.AddDireccion(objetoStreet, null, objContacto);
                    }

                    /***************************************************************************************************************************/

                    // Si el resultado que nos devuelve el servicio es != -1 llevamos al usuario a una web ( GestionEmpresa o GestionContacto )
                    if (res != -1)
                    {
                        if (cEmp != 0) Response.Redirect("gestionEmpresas.aspx");
                        if (cCon != 0) Response.Redirect("gestionContacto.aspx");
                    }
                    // Si el resultado que nos devuelve la BD no es valido, mostraremos un error en el formulario
                    else
                    {
                        //this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                        //this.alert.Visible = true;
                    }

                    /***************************************************************************************************************************/
                }// Fin del if
            }// Fin del if
        }// Fin del addDirec

        /// <summary>
        /// Evento que nos devuelve a la pagina donde volvimos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Volver(object sender, EventArgs e)
        {
            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            if (cEmp <= 0 && cCon <= 0)
            {
                Response.Redirect(".aspx", true);
            }

            if (cEmp != 0)
            {
                Response.Redirect("gestionEmpresas.aspx", true);
            }

            if (cCon != 0)
            {
                Response.Redirect("gestionContacto.aspx", true);
            }
        }// Fin del protected void Volver
    }
}
