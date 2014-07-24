using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addTelefono : System.Web.UI.Page
    {
        /// <summary>
        /// Usamos el Page_Load para mostrar la empresa o el contacto al que vamos añadir el telefono al cargar la pagina web
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
                this.labeltelefono.Text = objEmpresa.nombreComercial;
            }
            else
            {
                if (cCon != 0)
                {
                    var objContacto = proxy.getContacto(cCon);
                    this.labeltelefono.Text = objContacto.nombre;
                }
                else
                {
                    this.labeltelefono.Text = "-Sin informacion de empresa o contacto-";
                    this.lblError.Visible = true;
                    this.lblError.Text = "No se ha accedido correctamente a esta pagina web, haz click en volver y acceda correctamente";
                    this.btnEnviar.Visible = false;
                    this.telepone.Visible = false;
                    this.tlf.Visible = false;
                    this.lblError.CssClass = "page-header alert alert-danger";
                    this.btnVolver.CssClass = "btn btn-danger btn-lg col-md-4 col-md-offset-3";
                }
            }
            // Si recibimos el idContacto mostramos el contacto al que le vamos añadir un email
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

                        // Cogemos los id de empresa y contacto.
                        int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
                        int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

                        /***************************************************************************************************************************/
                        if (cEmp != 0) // Si el id que nos da de empresa realizamos la siguiente operación.
                        {
                            var objEmpresa = proxy.getEmpresaId(cEmp); // Obtengo el objeto empresa a partir del ID que nos dan por url

                            // Creamos un objeto telefono, inicializando el telefonoo con lo que me devuelve el metodo. Me puede devolver 2 cosas, o null o el telefonoo.
                            TelefonoData telefono = proxy.GetNumeroTelefono(this.telepone.Text);

                            if(telefono==null) // Si el telefono que recibo es null, quiere decir que el telefono no existe
                            {
                                TelefonoData tlf = new TelefonoData();

                                tlf.numero = this.telepone.Text;

                                proxy.AddTelefono(tlf, objEmpresa, null);
                                Response.Redirect("gestionEmpresas.aspx");
                            }
                            else
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                            }
                         }// Fin del if
                        /***************************************************************************************************************************/

                        /***************************************************************************************************************************/
                        if (cCon != 0)
                        {
                            var objetoContacto = proxy.getContacto(cCon); // Obtengo el objeto empresa a partir del ID que nos dan por url

                            // Creamos un objeto telefono, inicializando el telefonoo con lo que me devuelve el metodo. Me puede devolver 2 cosas, o null o el telefonoo.
                            TelefonoData telefono = proxy.GetNumeroTelefono(this.telepone.Text);

                            if (telefono == null) // Si el telefono que recibo es null, quiere decir que el telefono no existe
                            {
                                TelefonoData tlf = new TelefonoData();

                                tlf.numero = this.telepone.Text;
                                proxy.AddTelefono(tlf, null, objetoContacto);
                                /**** Vamos a obtener el id del contacto de la empresa *****/
                                var idEmpresa = objetoContacto.idEmpresa;
                                /********/
                                Response.Redirect("gestionContacto.aspx?id=" + idEmpresa);
                            }
                            else
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                            }
                        }
                        /***************************************************************************************************************************/
                    }
                    catch (Exception err)
                    {
                         this.lblError.Visible = true;
                         this.lblError.Text = err.Message;
                        // this.alert.Visible = true;    
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
