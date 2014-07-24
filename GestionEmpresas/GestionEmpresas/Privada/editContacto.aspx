<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editContacto.aspx.cs" Inherits="GestionEmpresas.Privada.editContacto" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar contacto</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
             <br /><br />
            <div class="panel panel-primary text-center col-md-8 col-md-offset-2">
                    <div class="panel-heading"> 
                          <h1> Editar contacto  </h1>
                          - <asp:Label ID="labelContacto" runat="server" Text=""></asp:Label> - 
                    </div> 
                    <div class="panel-body">
                       <br /><br />
                       <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="nm" runat="server">Nombre</asp:Label>   
                            </section>                       
                            <section class="col-md-4">
                                     <asp:TextBox id="nomb" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"
                                             ErrorMessage="Debes rellenar el nombre del contacto" ControlToValidate="nomb" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpression" runat="server"
                                             ErrorMessage="Solo se admiten letras" ValidationExpression="[A-Za-z ]*" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="nomb"></asp:RegularExpressionValidator>
                            </section>
                        </article>
                        <!-- NECESITA UN METODO QUE VALIDE CORRECTAMENTE EL DNI -->
                        <article class="col-md-11 col-md-offset-2"> 
                            <section class="col-md-2 col-md-offset-1">
                                <asp:Label ID="nnif" runat="server">NIF</asp:Label>   
                            </section>                       
                            <section class="col-md-4">
                                <asp:TextBox ID="nf" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                         ErrorMessage="Debes rellenar el campo NIF" ControlToValidate="nf" CssClass="glyphicon glyphicon-asterisk alert-danger"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                         ErrorMessage="El nif no es valido" ValidationExpression="(\d{8})([-]?)([A-Z]{1})" CssClass="glyphicon glyphicon-remove alert-danger" ControlToValidate="nf"></asp:RegularExpressionValidator>         
                            </section>
                        </article><br /><br /><br /><br /><br /><br />
                        <asp:Label ID="lblError" runat="server" CssClass="label label-danger" Text="Label"></asp:Label>
                        <br /><br /><br /><br /><br />

                        <footer class="col-md-12 col-md-offset-1">  
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-danger col-md-4" OnClick="Volver" CausesValidation="False"  />
                            <asp:Button ID="btnEnviar" runat="server" Text="Editar cambios" CssClass="btn btn-success col-md-4 col-md-offset-2" OnClick="btnEditarContacto" OnClientClick="return confirm('¿Deseas guardar los cambios realizados?');" /> 
                        </footer>
                        <br /><br /><br />
              </div> <!-- panel-heading -->
            </div> <!-- panel panel-primary -->
        </div> <!-- Fin del row -->
    </div> <!-- Fin del container -->
    </form>
</body>
</html>

