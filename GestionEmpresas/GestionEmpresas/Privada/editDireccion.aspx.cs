using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class editDireccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ServicioGestionClient proxy = new ServicioGestionClient();

                // Obtemos el id del email
                int idDireccion = Convert.ToInt32(Request.QueryString["id"]);
                var direccion = proxy.GetDireccion(idDireccion);

                this.labelDireccion.Text = direccion.domicilio;

                this.domici.Text = direccion.domicilio;
                this.poblac.Text = direccion.poblacion;
                this.cp.Text = direccion.codPostal; 
                this.provin.Text = direccion.provincia;
            }
        }

        protected void editDirec(object sender, EventArgs e)
        {

            if (this.IsPostBack)
            {
                this.Validate();

                if (this.IsValid)
                {

                    ServicioGestionClient proxy = new ServicioGestionClient();

                    // En estas dos variables almacenamos el numero del idempresa o idcontacto y un cero.
                    int idDireccion = Convert.ToInt32(Request.QueryString["id"]);
                    int res = -1; // Inicializamos el resultado a valor -1

                    /** Objeto direccion **/

                    DireccionData objetoStreet = new DireccionData();

                    objetoStreet.idDireccion = idDireccion;
                    objetoStreet.domicilio = this.domici.Text;
                    objetoStreet.poblacion = this.poblac.Text;
                    objetoStreet.codPostal = this.cp.Text;
                    objetoStreet.provincia = this.provin.Text;

                    /** Fin objeto direccion **/

                    /***************************************************************************************************************************/

                    // Si la empresa es distinto a cero, procedemos a guardar los datos a la BD.
                    if (idDireccion != 0)
                    {
                        // Obtengo el objeto empresa
                        res = proxy.EditDireccion(objetoStreet);
                    }



                    /***************************************************************************************************************************/

                    // Si el resultado que nos devuelve el servicio es != -1 llevamos al usuario a una web ( GestionEmpresa o GestionContacto )
                    if (res != -1)
                    {
                        if (res != 0) Response.Redirect("Default.aspx");
                    }
                    // Si el resultado que nos devuelve la BD no es valido, mostraremos un error en el formulario
                    else
                    {
                        //this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                        //this.alert.Visible = true;
                    }

                    /***************************************************************************************************************************/
                } // Fin del if (this.IsValid)
            }// Fin del if (this.IsPostBack)
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Volver(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();

            int idDireccion = Convert.ToInt32(Request.QueryString["id"]); // Obtengo el id de direccion

            var obtenerDireccionEmpresa = proxy.GetDireccion(idDireccion); 

            
            


        }
    }
}
