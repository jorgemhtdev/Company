using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();
            EmpresaData[] empresas = proxy.getAllEmpresa();
            ContactoData[] contactos = proxy.getAllContacto();
            AccionComercialMostrarData[] acciones = proxy.getAllAccionesComerciales();
            UsuarioData[] usuarios = proxy.getAllUsuarios();


            int numTotalContactos = contactos.ToList().Count;
            int numTotalEmpresas = empresas.ToList().Count;
            int numTotalAcciones = acciones.ToList().Count;
            int numTotalUsuarios = usuarios.ToList().Count;

            this.lblTotalAccionesComerciales.Text = Convert.ToString(numTotalAcciones);
            this.lblTotalEmpresa.Text = Convert.ToString(numTotalEmpresas);
            this.lblTotalContactos.Text = Convert.ToString(numTotalContactos);
            this.lblTotalUsuarios.Text = Convert.ToString(numTotalUsuarios);
        }
    }
}