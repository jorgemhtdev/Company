using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class addAccionComercial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();

                    /*************************************************** USUARIOS ***************************************************

                    var user = proxy.getAllUsuarios(); 

                    this.listaUser.DataSource = user; 

                    this.listaUser.DataTextField = "login";
                    this.listaUser.DataValueField = "idUsuario";

                    this.listaUser.DataBind();

                    /*************************************************** USUARIOS ***************************************************/

                    /************************************************* TIPO ACCION *************************************************/

                    var tipoaccion = proxy.GetAllTipoAccion();

                    this.listaAccion.DataSource = tipoaccion;

                    this.listaAccion.DataTextField = "descripcion";
                    this.listaAccion.DataValueField = "idTipoAccion";

                    this.listaAccion.DataBind();

                    /************************************************* TIPO ACCION *************************************************/

                    /********************************************* ESTADO DE ACCION ************************************************/

                    var estadoAccion = proxy.GetEstadoAccion();

                    this.listaEstadoAccion.DataSource = estadoAccion;

                    this.listaEstadoAccion.DataTextField = "descripcion";
                    this.listaEstadoAccion.DataValueField = "idEstadoAccion";

                    this.listaEstadoAccion.DataBind();

                    /********************************************* ESTADO DE ACCION ************************************************/

                    /*************************************************** EMPRESA ***************************************************

                    var empresa = proxy.getAllEmpresa();

                    this.listaEmpresa.DataSource = empresa;
                    this.listaEmpresa.DataSource = empresa;

                    this.listaEmpresa.DataTextField = "nombreComercial";
                    this.listaEmpresa.DataValueField = "EmpresaID";

                    this.listaEmpresa.DataBind();

                    //this.listaEmpresa.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));

                    /*************************************************** EMPRESA ***************************************************/

                }
                catch
                {
                    // this.lblError.Text = err.Message;
                    // this.alert.Visible = true; 

                    // O en sector del drownlist meter no hay datos disponibles y quitar los botones
                }
            }
        }// Fin del Page_Load

        /// <summary>
        /// Evento que nos añade una Accion Comercial a la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addAC(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {

                this.Validate();
                if (this.IsValid)
                {

                    ServicioGestionClient proxy = new ServicioGestionClient();

                    /** Objeto direccion **/

                    AccionComercialData objetoAccionComercial = new AccionComercialData();

                    /** Las listas despegables **/
                    objetoAccionComercial.idUsuario = proxy.GetNombreUsuario(this.listaUser.Text).idUsuario;
                    objetoAccionComercial.idTipoAccion = Convert.ToInt32(this.listaAccion.Text);
                    objetoAccionComercial.idEstadoAccion = Convert.ToInt32(this.listaEstadoAccion.Text);
                    objetoAccionComercial.idEmpresa = proxy.GetNombreEmpresa(this.listaEmpresa.Text).EmpresaID;
                    /** Las listas despegables **/

                    objetoAccionComercial.fechaHora = Convert.ToDateTime(this.fch.Text);

                    /// Al ser text tarea a la hora de recoger los datos del formulario cambia un poco, hay que añadir runat server en el aspx y luego en C# se ha de escribir
                    /// la siguiente linea --> Para más información : http://stackoverflow.com/questions/4508051/textarea-control-asp-net-c-sharp
                    objetoAccionComercial.comentarios = this.TextAreaComentarios.Value;
                    objetoAccionComercial.descripcion = this.TextAreaDescripcion.Value;

                    /** Fin objeto direccion **/

                    proxy.addAccionComercial(objetoAccionComercial);

                    Response.Redirect("gestionAccionesComerciales.aspx", true);

                } // Fin del if (this.IsValid)
            }// Fin del if (this.IsPostBack)
        } // Fin del evento addAC

        /// <summary>
        /// Evento que me lleva a la pagina gestionUsuarios.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Volver(object sender, EventArgs e)
        {
            Response.Redirect("gestionAccionesComerciales.aspx", true);
        }// Fin del protected void Volver

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();
            if (proxy.GetNombreEmpresa(this.listaEmpresa.Text) == null)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ServicioGestionClient proxy = new ServicioGestionClient();
            if (proxy.GetNombreUsuario(this.listaUser.Text) == null)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}
