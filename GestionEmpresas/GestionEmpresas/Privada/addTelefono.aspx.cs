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
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();

            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            if (cEmp != 0)
            {
                var objEmpresa = proxy.getEmpresaId(cEmp);
                this.labeltelefono.Text = objEmpresa.nombreComercial;
            }

            else
            {
                if (cEmp != 0)
                {
                    var objEmpresa = proxy.getEmpresaId(cEmp);
                    this.labeltelefono.Text = objEmpresa.nombreComercial;
                }
            }
        }
        
        /// <summary>
        /// Este metodo añadir telefono tiene dos variables, cEmp y cCon. Una de las dos variables va a tener un valor y el otro va a tener un valor cero. Si el valor
        /// es !=0 trabajaremos con ese objeto y si es igual a cero no utilizaremos ese objeto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addTlf(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();

            try
            {

                int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
                int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);
                int res = -1;

                if (cEmp != 0)
                {
                    // Obtengo el objeto empresa
                    var objEmpresa = proxy.getEmpresaId(cEmp);
                    
                    // Me creo un objeto telefono
                    TelefonoData t = new TelefonoData() { numero = this.telepone.Text };

                    // Añado el telefono al objeto empresa  int AddTelefono(TelefonoData t, EmpresaData empData, ContactoData conData);
                    res = proxy.AddTelefono(t, objEmpresa, null);

                    // Si es distinto a -1 me lleva a la siguiente url, todo esta ok 
                    if (res != -1) Response.Redirect("gestionEmpresas.aspx");
                    else
                    {
                        //this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                        //this.alert.Visible = true;
                    }
                }

                if (cCon != 0)
                {
                    // Obtengo el objeto contacto
                    var objContacto = proxy.getContacto(cCon);
                    
                    // Me creo un objeto telefono
                    TelefonoData t = new TelefonoData() { numero = this.telepone.Text };
                    
                    // Añado el telefono al objeto contacto int AddTelefono(TelefonoData t, EmpresaData empData, ContactoData conData);
                    res = proxy.AddTelefono(t, null, objContacto);
                    
                    // Si el distinto a -1 me lleva a l siguiente url, todo esta ok
                    if (res != -1) Response.Redirect("gestionContacto.aspx");
                    else
                    {
                        //this.lblError.Text = "No se guardaron los datos, error de acceso al servicio";
                        //this.alert.Visible = true;
                    }
                }

            }
            catch (Exception err)
            {
                // this.lblError.Text = err.Message;
                // this.alert.Visible = true;    
            }
        } // Fin del addTlf


        protected void Volver(object sender, EventArgs e)
        {
            int cEmp = Convert.ToInt32(Request.QueryString["Empresa"]);
            int cCon = Convert.ToInt32(Request.QueryString["Contacto"]);

            this.telepone.Text = "123456789";

            if (cEmp <= 0 && cCon <= 0)
            {
                Response.Redirect(".aspx", true);
            }

            if (cEmp != 0)
            {
                Response.Redirect("gestionContacto.aspx", true);
            }

            if (cCon != 0)
            {
                Response.Redirect("gestionContacto.aspx", true);
            }
        }// Fin del protected void Volver(object sender, EventArgs e)
    }
}
