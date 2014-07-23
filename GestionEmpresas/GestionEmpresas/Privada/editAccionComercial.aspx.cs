using GestionEmpresas.srvGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionEmpresas.Privada
{
    public partial class editAccionComercial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    ServicioGestionClient proxy = new ServicioGestionClient();
                    int id = Convert.ToInt32(Request.QueryString["id"]); // Obtengo el id           
                    var AccionComercial = proxy.getAccionComercial(id); // Obtengo la accion comercial ( el objeto )

                    /*************************************************** USUARIOS ***************************************************/

                    this.listaUser.Text = proxy.getUsuario(AccionComercial.idUsuario).nombre;
  
                    /*var user = proxy.getAllUsuarios(); // Obtengo los usuarios

                    int contadorUser = 0;

                    for(int x=0; x<proxy.getAllUsuarios().Count(); x++){
                        if (AccionComercial.idUsuario == user[x].idUsuario)
                        {
                            break;
                        }
                        contadorUser++;
                    }// Fin del for

                    this.listaUser.DataSource = user;
                    this.listaUser.SelectedIndex = contadorUser;
                    this.listaUser.DataTextField = "login";
                    this.listaUser.DataValueField = "idUsuario";

                    this.listaUser.DataBind();

                    /*************************************************** USUARIOS ***************************************************/

                    /************************************************* TIPO ACCION *************************************************/

                    var tipoaccion = proxy.GetAllTipoAccion();

                    int contadorAccion = 0;

                    for (int x = 0; x < proxy.GetAllTipoAccion().Count(); x++)
                    {
                        if (AccionComercial.idTipoAccion == tipoaccion[x].idTipoAccion)
                        {
                            break;
                        }
                        contadorAccion++;
                    }// Fin del for

                    this.listaAccion.DataSource = tipoaccion;
                    this.listaAccion.SelectedIndex = contadorAccion;
                    this.listaAccion.DataTextField = "descripcion";
                    this.listaAccion.DataValueField = "idTipoAccion";

                    this.listaAccion.DataBind();

                    /************************************************* TIPO ACCION *************************************************/

                    /********************************************* ESTADO DE ACCION ************************************************/

                    var estadoAccion = proxy.GetEstadoAccion();

                    int contadorEstadoAccion = 0;

                    for (int x = 0; x < proxy.GetEstadoAccion().Count(); x++)
                    {
                        if (AccionComercial.idEstadoAccion == estadoAccion[x].idEstadoAccion)
                        {
                            break;
                        }
                        contadorEstadoAccion++;
                    }// Fin del for

                    this.listaEstadoAccion.DataSource = estadoAccion;
                    this.listaEstadoAccion.SelectedIndex = contadorEstadoAccion;
                    this.listaEstadoAccion.DataTextField = "descripcion";
                    this.listaEstadoAccion.DataValueField = "idEstadoAccion";

                    this.listaEstadoAccion.DataBind();

                    /********************************************* ESTADO DE ACCION ************************************************/

                    /*************************************************** EMPRESA ***************************************************/

                    this.listaEmpresa.Text = proxy.getEmpresaId(AccionComercial.idEmpresa).nombreComercial;

                    /*var empresa = proxy.getAllEmpresa();

                    int contadorEmpresa = 0;

                    for (int x = 0; x < proxy.getAllEmpresa().Count(); x++)
                    {
                        if (AccionComercial.idEmpresa == empresa[x].EmpresaID)
                        {
                            break;
                        }
                        contadorEmpresa++;
                    }// Fin del for

                    this.listaEmpresa.DataSource = empresa;
                    this.listaEmpresa.SelectedIndex = contadorEmpresa;
                    this.listaEmpresa.DataTextField = "nombreComercial";
                    this.listaEmpresa.DataValueField = "EmpresaID";

                    this.listaEmpresa.DataBind();

                    //this.listaEmpresa.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));

                    /*************************************************** EMPRESA ***************************************************/

                    
                    //this.fch.Text = AccionComercial.fechaHora.ToString("d");

                    this.fch.Text = AccionComercial.fechaHora.ToString("yyy-MM-dd");

                    this.TextAreaComentarios.Value = AccionComercial.comentarios;
                    this.TextAreaDescripcion.Value = AccionComercial.descripcion;
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
                    objetoAccionComercial.idAccion = Convert.ToInt32(Request.QueryString["id"]);
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

                    proxy.editAccionComercial(objetoAccionComercial);

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
