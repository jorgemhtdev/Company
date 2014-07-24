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

                int idDireccion = Convert.ToInt32(Request.QueryString["id"]);
                var direccion = proxy.GetDireccion(idDireccion);

                this.domici.Text = direccion.domicilio;
                this.poblac.Text = direccion.poblacion;
                this.cp.Text = direccion.codPostal;
                this.provin.Text = direccion.provincia;
            }
            else
            {
                // Si recibimos el idContacto mostramos el contacto al que le vamos añadir un email
                if (cCon != 0)
                {
                    int idDireccion = Convert.ToInt32(Request.QueryString["id"]);

                    var objContacto = proxy.getContacto(cCon);
                    this.labeldireccion.Text = objContacto.nombre;

                    var direccion = proxy.GetDireccion(idDireccion);

                    this.domici.Text = direccion.domicilio;
                    this.poblac.Text = direccion.poblacion;
                    this.cp.Text = direccion.codPostal;
                    this.provin.Text = direccion.provincia;
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
