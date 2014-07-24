<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addAccionComercial.aspx.cs" Inherits="GestionEmpresas.Privada.addAccionComercial" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Añadir Acción Comercial</title>
   <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
             <br /><br />
            <div class="panel panel-primary text-center col-md-8 col-md-offset-2">
                <div class="panel-heading"> <h1> Añadir acción comercial </h1></div>
                    <div class="panel-body">
                       <br /><br />
                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="user" runat="server">Usuario</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <asp:TextBox ID="listaUser" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="listaUser" CssClass="glyphicon glyphicon-remove alert-danger" Display="Dynamic" ErrorMessage="Compruebe el nombre de usuario" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ControlToValidate="listaUser" ID="CustomValidator3" runat="server" CssClass="glyphicon glyphicon-remove alert-danger" ErrorMessage="Compruebe el nombre de usuario" OnServerValidate="CustomValidator3_ServerValidate" EnableClientScript="False" SetFocusOnError="True"></asp:CustomValidator>
                            </section>
                        </article>
                        
                        <br /><br /><br /><br />

                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="acción" runat="server">Tipo Acción</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <asp:DropDownList ID="listaAccion" runat="server" CssClass="form-control" TabIndex="2"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="listaAccion" CssClass="glyphicon glyphicon-remove alert-danger" ErrorMessage="Seleccione un tipo de acción comercial"></asp:RequiredFieldValidator>
                            </section>
                        </article>
                        
                        <br /><br /><br /><br />

                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="staAcc" runat="server">Estado de acción</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <asp:DropDownList ID="listaEstadoAccion" runat="server" CssClass="form-control" TabIndex="3"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="listaEstadoAccion" CssClass="glyphicon glyphicon-remove alert-danger" ErrorMessage="Seleccione un estado de acción comercial"></asp:RequiredFieldValidator>
                            </section>
                        </article>
                        
                        <br /><br /><br /><br />

                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="emp" runat="server">Empresa</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <asp:TextBox ID="listaEmpresa" runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="listaEmpresa" CssClass="glyphicon glyphicon-remove alert-danger" Display="Dynamic" ErrorMessage="Compruebe el nombre de empresa" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ControlToValidate="listaEmpresa" ID="CustomValidator4" runat="server" CssClass="glyphicon glyphicon-remove alert-danger" ErrorMessage="Compruebe el nombre de empresa" OnServerValidate="CustomValidator4_ServerValidate" EnableClientScript="False"></asp:CustomValidator>
                            </section>
                        </article>
                        
                        <br /><br /><br /><br />
                        
                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="fech" runat="server">Fecha</asp:Label>   
                            </section>                       
                            <section class="col-md-4">
                                <asp:TextBox ID="fch" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                         ErrorMessage="El campo fecha no puede quedarse vacio" ControlToValidate="fch" CssClass="glyphicon glyphicon-asterisk alert-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <!-- La fecha es AÑO MES DIA -->
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                         ErrorMessage="El formato de la fecha es: ' año-mes-dia ' (sin comillas)" ValidationExpression="^\d{2,4}\-\d{1,2}\-\d{1,2}$" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="fch" EnableClientScript="False" SetFocusOnError="True"></asp:RegularExpressionValidator>         
                            </section>
                        </article>

                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="cmtar" runat="server" >Comentarios</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                               <textarea id="TextAreaComentarios" cols="40" rows="5"  runat="server" tabindex="6"></textarea>
                            </section>
                        </article><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="dspc" runat="server" >Descripcion</asp:Label>                        
                            </section>
                            <section class="col-md-4">
                                <textarea id="TextAreaDescripcion" cols="40" rows="2"  runat="server" tabindex="7"></textarea>
                            </section>
                        </article> <br /><br /><br /><br /><br /><br /><br />

                        <footer class="col-md-12 col-md-offset-1">
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-danger col-md-4" OnClick="Volver" CausesValidation="False" TabIndex="9" />
                            <asp:Button ID="btnEnviar" runat="server" Text="Añadir" CssClass="btn btn-success col-md-4 col-md-offset-2" OnClick="addAC" OnClientClick="return confirm('¿Estas seguro de guardar estos cambios?');" TabIndex="8" /> 
                        </footer>
                        <br /><br /><br />
              </div> <!-- panel-heading -->
            </div> <!-- panel panel-primary -->
        </div> <!-- Fin del row -->
    </div> <!-- Fin del container -->
    </form>
</body>
</html>