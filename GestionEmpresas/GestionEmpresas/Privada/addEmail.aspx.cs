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
        /// <summary>
        /// Usamos el Page_Load para mostrar la empresa o el contacto al que vamos añadir el email al cargar la pagina web
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.lblError.Visible = false;

            ServicioGestionClient proxy = new ServicioGestionClient();

            // Obtemos el idEmpresa o el idContacto que nos dan por la url
            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            if (cEmp != 0 && cCon != 0) this.labelmail.Text = " - Sin informacion - ";

            // Si recibimos el idEmpresa mostramos el contacto al que le vamos añadir un email
            if (cEmp != 0)
            {
                var objEmpresa = proxy.getEmpresaId(cEmp);
                this.labelmail.Text = objEmpresa.nombreComercial;
            }

            // Si recibimos el idContacto mostramos el contacto al que le vamos añadir un email
            if (cCon != 0)
            {
                var objContacto = proxy.getContacto(cCon);
                this.labelmail.Text = objContacto.nombre;
            }
        }// Fin del Page_Load

        /// <summary>
        /// Evento del boton que añade los input a nuestra BD. Los datos recogidos creamos un objeto Email, despues debemos de tener en cuenta si es para una empresa o 
        /// para un contacto. Para ello utilizamos el request QueryString que nos recoge dos numeros, uno que nos dan por el formulario y otro que es un cero.
        /// Si es cero, no realizamos ninguna operación y operamos sobre el numero !=0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addMail(object sender, EventArgs e)
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

                            // Creamos un objeto mail, inicializando el email con lo que me devuelve el metodo. Me puede devolver 2 cosas, o null o el email.
                            EmailData email = proxy.getEmailCorreo(this.mail.Text);

                            if (email == null)// Si el objeto mail es null
                            {
                                proxy.addEmail(this.mail.Text, objEmpresa, null);
                                Response.Redirect("gestionEmpresas.aspx");
                            }
                            else // Si el objeto mail no es null, es que ese email existe ya en la base de datos. Procedemos a mostrarlo con un mensaje de error.
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "No se puede añadir este registro. El email ya existe en la base de datos.";
                            }

                        }// Fin del cEmp != 0

                        /***************************************************************************************************************************/

                        /***************************************************************************************************************************/

                        // Si el id que nos dan es de contacto realizamos la siguiente operación.
                        if (cCon != 0)
                        {

                            var objContacto = proxy.getContacto(cCon); // Obtengo el objeto contacto a partir del ID que nos dan por url

                            // Creamos un objeto mail, inicializando el email con lo que me devuelve el metodo. Me puede devolver 2 cosas, o null o el email.
                            EmailData email = proxy.getEmailCorreo(this.mail.Text);

                            if (email == null) // Si el email es nulo
                            {
                                proxy.addEmail(this.mail.Text, null, objContacto);
                                /**** Vamos a obtener el id del contacto de la empresa *****/
                                int idContacto = objContacto.idContacto;
                                var idcontactoEmpresa = proxy.getContacto(idContacto);
                                var idEmpresa = idcontactoEmpresa.idEmpresa;
                                /********/
                                Response.Redirect("gestionContacto.aspx?id=" + idEmpresa);
                            }
                            else
                            {
                                this.lblError.Visible = true;
                                this.lblError.Text = "No se puede añadir este registro. El email ya existe en la base de datos.";
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        this.lblError.Visible = true;
                        this.lblError.Text = err.Message;
                    }// Fin del catch
                } // Fin del if (this.IsValid)
            }// Fin del if (this.IsPostBack)
        }// Fin del addMail

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
                //var idEmpresa = objContacto.idEmpresa
                int idContacto = objContacto.idContacto; // Obtengo el id del contacto
                var idcontactoEmpresa = proxy.getContacto(idContacto); // Obtengo el id del contacto de la empresa 
                var idEmpresa = idcontactoEmpresa.idEmpresa; // 
                /****************/
                Response.Redirect("gestionContacto.aspx?id=" + idEmpresa);
            }
        }// Fin del protected void Volver
    }
}
